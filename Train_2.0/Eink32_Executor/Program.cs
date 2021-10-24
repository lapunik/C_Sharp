using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Eink32_Executor
{
    class Executor_Program
    {
        static ConfigExec cfg = null;
        static Dictionary<char, Process> dProcesy = new Dictionary<char, Process>();

        static void Log(String txt)   // cannot use default parameter of Color type
        {
            Log(txt, Color.Transparent);
           
        }

        static void Log(String txt, Color color)
        {
            String s = String.Format("{0:HH:mm:ss.fff} - {1}", DateTime.Now, txt);

            if (color == Color.Transparent)
                Console.WriteLine(s);
            else
                Console.WriteLine(s, color);
        }

        static void Main(string[] args)
        {
            cfg = ConfigExec.Load();

            Log("Executor START", Color.Yellow);
            Log(new String('=', 40));
            Log("Settings:");

            foreach (ExecItem item in cfg.Items)
                Log(String.Format("{0} {1} - {2}", item.ControlChar, item.AutoStart, item.FileName));

            foreach (ExecItem item in cfg.Items)
            {
                Process p = new Process() { StartInfo = new ProcessStartInfo(item.FileName) { Arguments = item.Parameter} };
                dProcesy.Add(item.ControlChar, p);

                if (item.AutoStart)
                {
                    if (item.StartPreDelayMs > 0)
                        Thread.Sleep(item.StartPreDelayMs);

                    try
                    {
                        p.Start();
                    }
                    catch (Exception ex)
                    {
                        Log(ex.Message, Color.OrangeRed);
                    }

                    if (item.StartPostDelayMs > 0)
                        Thread.Sleep(item.StartPostDelayMs);

                    Log("Started " + item.FileName, Color.LightGreen);
                }
            }

            //first init XMLcfg.Items.Add(new ExecItem() { AutoStart = true, ControlChar = 'A', FileName = "dummy.exe", StartPreDelayMs = 100 });

            int cntSec = 0;
            bool doIt = true;
            while (doIt)
            {
                if (Console.KeyAvailable)
                {
                    char c = Char.ToUpperInvariant(Console.ReadKey(true).KeyChar);   // neukazuj pismenka

                    switch (c)
                    {
                        case 'Q':
                            doIt = false;
                            break;
                        case 'S':
                            cfg.Save(ConfigExec.defaultConfigFileName);
                            break;
                        default:
                            bool found = false;
                            foreach (ExecItem item in cfg.Items)
                            {
                                if (item.ControlChar == c)
                                {
                                    found = true;

                                    foreach (KeyValuePair<char, Process> kvp in dProcesy)
                                    {
                                        if (kvp.Key == item.ControlChar)
                                        {
                                            Log(item.FileName);

                                            if (kvp.Value.HasExited)
                                            {
                                                kvp.Value.Start();
                                                Log(" started");
                                            }
                                            else
                                            {
                                                kvp.Value.CloseMainWindow();
                                                Log(" closed");
                                            }

                                            break;
                                        }
                                    }
                                }
                            }

                            if (found)
                                break;

                            Log("?", Color.OrangeRed);
                            break;
                    }
                }

                Thread.Sleep(100);

                cntSec++;
                if (cntSec >= 10)
                {
                    cntSec = 0;

                    foreach (ExecItem item in cfg.Items)
                    {
                        if ((Process.GetProcessesByName(Path.GetFileNameWithoutExtension(item.FileName)).Length == 0)
                          || (dProcesy[item.ControlChar].HasExited))
                        {
                            //Log(dProcesy[item.ControlChar].ProcessName + " crashed ?", Color.OrangeRed);
                            Log(item.FileName + " crashed ?", Color.OrangeRed);

                            if (item.AutoRestart)
                            {
                                Log("Try to ReStart " + item.FileName);

                                try
                                {
                                    dProcesy[item.ControlChar].Start();
                                }
                                catch (Exception ex)
                                {
                                    Log(ex.Message, Color.OrangeRed);
                                }
                            }
                        }
                    }
                }
            }

            foreach (Process p in dProcesy.Values)
            {
                try
                {
                    if (!p.HasExited)
                    {
                        p.CloseMainWindow();
                        Log(p.ProcessName + " closed");
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.Message, Color.OrangeRed);
                }

                p.Dispose();
            }

            Log("Executor END", Color.Yellow);
        }
    }
}