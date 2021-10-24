using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKEY
{
    public partial class Form_Help : Form
    {
        public Form_Help()
        {
            InitializeComponent();

            richTextBox_help.Rtf = @"{\rtf1\adeflang1025\ansi\ansicpg1250\uc1\adeff37\deff0\stshfdbch31505\stshfloch31506\stshfhich31506\stshfbi0\deflang1029\deflangfe1029\themelang1029\themelangfe0\themelangcs0{\fonttbl{\f0\fbidi \froman\fcharset238\fprq2{\*\panose 02020603050405020304}Times New Roman;}
{\f34\fbidi \froman\fcharset238\fprq2{\*\panose 02040503050406030204}Cambria Math;}{\f37\fbidi \fswiss\fcharset238\fprq2{\*\panose 020f0502020204030204}Calibri;}
{\f39\fbidi \fswiss\fcharset0\fprq2{\*\panose 00000000000000000000}Liberation Sans{\*\falt Arial};}{\f40\fbidi \fswiss\fcharset238\fprq2{\*\panose 020f0302020204030204}Calibri Light;}
{\flomajor\f31500\fbidi \froman\fcharset238\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\fdbmajor\f31501\fbidi \froman\fcharset238\fprq2{\*\panose 02020603050405020304}Times New Roman;}
{\fhimajor\f31502\fbidi \froman\fcharset238\fprq2{\*\panose 02040503050406030204}Cambria;}{\fbimajor\f31503\fbidi \froman\fcharset238\fprq2{\*\panose 02020603050405020304}Times New Roman;}
{\flominor\f31504\fbidi \froman\fcharset238\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\fdbminor\f31505\fbidi \froman\fcharset238\fprq2{\*\panose 02020603050405020304}Times New Roman;}
{\fhiminor\f31506\fbidi \fswiss\fcharset238\fprq2{\*\panose 020f0502020204030204}Calibri;}{\fbiminor\f31507\fbidi \froman\fcharset238\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\f43\fbidi \froman\fcharset0\fprq2 Times New Roman;}
{\f42\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\f44\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\f45\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\f46\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}
{\f47\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\f48\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\f49\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\f383\fbidi \froman\fcharset0\fprq2 Cambria Math;}
{\f382\fbidi \froman\fcharset204\fprq2 Cambria Math Cyr;}{\f384\fbidi \froman\fcharset161\fprq2 Cambria Math Greek;}{\f385\fbidi \froman\fcharset162\fprq2 Cambria Math Tur;}{\f388\fbidi \froman\fcharset186\fprq2 Cambria Math Baltic;}
{\f389\fbidi \froman\fcharset163\fprq2 Cambria Math (Vietnamese);}{\f413\fbidi \fswiss\fcharset0\fprq2 Calibri;}{\f412\fbidi \fswiss\fcharset204\fprq2 Calibri Cyr;}{\f414\fbidi \fswiss\fcharset161\fprq2 Calibri Greek;}
{\f415\fbidi \fswiss\fcharset162\fprq2 Calibri Tur;}{\f418\fbidi \fswiss\fcharset186\fprq2 Calibri Baltic;}{\f419\fbidi \fswiss\fcharset163\fprq2 Calibri (Vietnamese);}{\f443\fbidi \fswiss\fcharset0\fprq2 Calibri Light;}
{\f442\fbidi \fswiss\fcharset204\fprq2 Calibri Light Cyr;}{\f444\fbidi \fswiss\fcharset161\fprq2 Calibri Light Greek;}{\f445\fbidi \fswiss\fcharset162\fprq2 Calibri Light Tur;}{\f448\fbidi \fswiss\fcharset186\fprq2 Calibri Light Baltic;}
{\f449\fbidi \fswiss\fcharset163\fprq2 Calibri Light (Vietnamese);}{\flomajor\f31510\fbidi \froman\fcharset0\fprq2 Times New Roman;}{\flomajor\f31509\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}
{\flomajor\f31511\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\flomajor\f31512\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\flomajor\f31513\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}
{\flomajor\f31514\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\flomajor\f31515\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\flomajor\f31516\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}
{\fdbmajor\f31520\fbidi \froman\fcharset0\fprq2 Times New Roman;}{\fdbmajor\f31519\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\fdbmajor\f31521\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}
{\fdbmajor\f31522\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\fdbmajor\f31523\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\fdbmajor\f31524\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}
{\fdbmajor\f31525\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\fdbmajor\f31526\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\fhimajor\f31530\fbidi \froman\fcharset0\fprq2 Cambria;}
{\fhimajor\f31529\fbidi \froman\fcharset204\fprq2 Cambria Cyr;}{\fhimajor\f31531\fbidi \froman\fcharset161\fprq2 Cambria Greek;}{\fhimajor\f31532\fbidi \froman\fcharset162\fprq2 Cambria Tur;}
{\fhimajor\f31535\fbidi \froman\fcharset186\fprq2 Cambria Baltic;}{\fhimajor\f31536\fbidi \froman\fcharset163\fprq2 Cambria (Vietnamese);}{\fbimajor\f31540\fbidi \froman\fcharset0\fprq2 Times New Roman;}
{\fbimajor\f31539\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\fbimajor\f31541\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\fbimajor\f31542\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}
{\fbimajor\f31543\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\fbimajor\f31544\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\fbimajor\f31545\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}
{\fbimajor\f31546\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\flominor\f31550\fbidi \froman\fcharset0\fprq2 Times New Roman;}{\flominor\f31549\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}
{\flominor\f31551\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\flominor\f31552\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\flominor\f31553\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}
{\flominor\f31554\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\flominor\f31555\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\flominor\f31556\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}
{\fdbminor\f31560\fbidi \froman\fcharset0\fprq2 Times New Roman;}{\fdbminor\f31559\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\fdbminor\f31561\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}
{\fdbminor\f31562\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\fdbminor\f31563\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\fdbminor\f31564\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}
{\fdbminor\f31565\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\fdbminor\f31566\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\fhiminor\f31570\fbidi \fswiss\fcharset0\fprq2 Calibri;}
{\fhiminor\f31569\fbidi \fswiss\fcharset204\fprq2 Calibri Cyr;}{\fhiminor\f31571\fbidi \fswiss\fcharset161\fprq2 Calibri Greek;}{\fhiminor\f31572\fbidi \fswiss\fcharset162\fprq2 Calibri Tur;}
{\fhiminor\f31575\fbidi \fswiss\fcharset186\fprq2 Calibri Baltic;}{\fhiminor\f31576\fbidi \fswiss\fcharset163\fprq2 Calibri (Vietnamese);}{\fbiminor\f31580\fbidi \froman\fcharset0\fprq2 Times New Roman;}
{\fbiminor\f31579\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\fbiminor\f31581\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\fbiminor\f31582\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}
{\fbiminor\f31583\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\fbiminor\f31584\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\fbiminor\f31585\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}
{\fbiminor\f31586\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}}{\colortbl;\red0\green0\blue0;\red0\green0\blue255;\red0\green255\blue255;\red0\green255\blue0;\red255\green0\blue255;\red255\green0\blue0;\red255\green255\blue0;
\red255\green255\blue255;\red0\green0\blue128;\red0\green128\blue128;\red0\green128\blue0;\red128\green0\blue128;\red128\green0\blue0;\red128\green128\blue0;\red128\green128\blue128;\red192\green192\blue192;\red46\green116\blue181;}{\*\defchp 
\fs22\loch\af31506\hich\af31506\dbch\af31505 }{\*\defpap \ql \li0\ri0\sa200\sl276\slmult1\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 }\noqfpromote {\stylesheet{\ql \li0\ri0\sa160\sl259\slmult1
\widctlpar\wrapdefault\hyphpar0\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af37\afs22\alang1025 \ltrch\fcs0 \fs22\lang1029\langfe1033\loch\f37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1033 \snext0 \sqformat \spriority0 Normal;}{\*\cs10 \additive 
Default Paragraph Font;}{\*\ts11\tsrowd\trftsWidthB3\trpaddl108\trpaddr108\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblind0\tblindtype3\tscellwidthfts0\tsvertalt\tsbrdrt\tsbrdrl\tsbrdrb\tsbrdrr\tsbrdrdgl\tsbrdrdgr\tsbrdrh\tsbrdrv 
\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 \rtlch\fcs1 \af0\afs22\alang1025 \ltrch\fcs0 \fs22\lang1029\langfe1029\loch\f31506\hich\af31506\dbch\af31505\cgrid\langnp1029\langfenp1029 
\snext11 \ssemihidden \sunhideused \sqformat Normal Table;}{\s15\ql \li0\ri0\sb240\sl259\slmult1\keep\keepn\widctlpar\wrapdefault\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af40\afs32\alang1025 \ltrch\fcs0 
\fs32\cf17\lang1029\langfe1029\loch\f40\hich\af37\dbch\af0\cgrid\langnp1029\langfenp1029 \sbasedon0 \snext0 Heading 1;}{\*\cs16 \additive \rtlch\fcs1 \af40\afs32 \ltrch\fcs0 \fs32\cf17\loch\f40\dbch\af0 \sbasedon10 Nadpis 1 Char;}{
\s17\ql \li0\ri0\sb240\sa120\sl259\slmult1\keepn\widctlpar\wrapdefault\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af39\afs28\alang1025 \ltrch\fcs0 \fs28\lang1029\langfe1029\loch\f39\hich\af37\dbch\af0\cgrid\langnp1029\langfenp1029 \sbasedon0 \snext18 Heading;}{
\s18\ql \li0\ri0\sa140\sl276\slmult1\widctlpar\wrapdefault\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af31507\afs24\alang1025 \ltrch\fcs0 \fs24\lang1029\langfe1029\loch\f37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1029 \sbasedon0 \snext18 Text Body;}{
\s19\ql \li0\ri0\sa140\sl276\slmult1\widctlpar\wrapdefault\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af31507\afs24\alang1025 \ltrch\fcs0 \fs24\lang1029\langfe1029\loch\f37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1029 \sbasedon18 \snext19 List;}{
\s20\ql \li0\ri0\sb120\sa120\sl259\slmult1\widctlpar\noline\wrapdefault\faauto\rin0\lin0\itap0 \rtlch\fcs1 \ai\af31507\afs24\alang1025 \ltrch\fcs0 \i\fs24\lang1029\langfe1029\loch\f37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1029 
\sbasedon0 \snext20 Caption;}{\s21\ql \li0\ri0\sa160\sl259\slmult1\widctlpar\noline\wrapdefault\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af31507\afs24\alang1025 \ltrch\fcs0 
\fs24\lang1029\langfe1029\loch\f37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1029 \sbasedon0 \snext21 Index;}}{\*\rsidtbl \rsid328988\rsid2780339\rsid13898843}{\mmathPr\mmathFont34\mbrkBin0\mbrkBinSub0\msmallFrac0\mdispDef1\mlMargin0\mrMargin0
\mdefJc1\mwrapIndent1440\mintLim0\mnaryLim1}{\info{\author Ondra}{\operator Ondra}{\creatim\yr2019\mo12\dy17\hr14\min54}{\revtim\yr2019\mo12\dy19\hr12\min16}{\version4}{\edmins1}{\nofpages1}{\nofwords139}{\nofchars632}{\nofcharsws770}{\vern32775}}
{\*\userprops {\propname AppVersion}\proptype30{\staticval 12.0000}{\propname DocSecurity}\proptype3{\staticval 0}{\propname HyperlinksChanged}\proptype11{\staticval 0}{\propname LinksUpToDate}\proptype11{\staticval 0}{\propname ScaleCrop}\proptype11
{\staticval 0}{\propname ShareDoc}\proptype11{\staticval 0}}{\*\xmlnstbl {\xmlns1 http://schemas.microsoft.com/office/word/2003/wordml}}\paperw11906\paperh16838\margl1417\margr1417\margt1417\margb1417\gutter0\ltrsect 
\deftab708\widowctrl\ftnbj\aenddoc\hyphhotz425\trackmoves1\trackformatting1\donotembedsysfont0\relyonvml0\donotembedlingdata1\grfdocevents0\validatexml0\showplaceholdtext0\ignoremixedcontent0\saveinvalidxml0\showxmlerrors0\formshade\horzdoc\dghspace120
\dgvspace120\dghorigin1701\dgvorigin1984\dghshow0\dgvshow3\jcompress\viewkind1\viewscale100\htmautsp\rsidroot328988 \fet0{\*\wgrffmtfilter 2450}\ilfomacatclnup0{\*\ftnsep \ltrpar \pard\plain \ltrpar\ql \li0\ri0\sa160\sl259\slmult1
\widctlpar\wrapdefault\hyphpar0\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af37\afs22\alang1025 \ltrch\fcs0 \fs22\lang1029\langfe1033\loch\af37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1033 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\fs24\lang1029\langfe1029\langfenp1029\insrsid328988 \chftnsep }{\rtlch\fcs1 \af37 \ltrch\fcs0 \insrsid328988 
\par }}{\*\ftnsepc \ltrpar \pard\plain \ltrpar\ql \li0\ri0\widctlpar\wrapdefault\hyphpar0\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af37\afs22\alang1025 \ltrch\fcs0 \fs22\lang1029\langfe1033\loch\af37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1033 {
\rtlch\fcs1 \af37 \ltrch\fcs0 \insrsid328988 \chftnsepc 
\par }}{\*\aftnsep \ltrpar \pard\plain \ltrpar\ql \li0\ri0\widctlpar\wrapdefault\hyphpar0\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af37\afs22\alang1025 \ltrch\fcs0 \fs22\lang1029\langfe1033\loch\af37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1033 {
\rtlch\fcs1 \af37 \ltrch\fcs0 \insrsid328988 \chftnsep 
\par }}{\*\aftnsepc \ltrpar \pard\plain \ltrpar\ql \li0\ri0\widctlpar\wrapdefault\hyphpar0\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af37\afs22\alang1025 \ltrch\fcs0 \fs22\lang1029\langfe1033\loch\af37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1033 {
\rtlch\fcs1 \af37 \ltrch\fcs0 \insrsid328988 \chftnsepc 
\par }}\ltrpar \sectd \ltrsect\sbknone\linex0\headery708\footery708\colsx708\sectunlocked1\sectdefaultcl\sftnbj {\*\pnseclvl1\pnucrm\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl2\pnucltr\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl3
\pndec\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl4\pnlcltr\pnstart1\pnindent720\pnhang {\pntxta )}}{\*\pnseclvl5\pndec\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl6\pnlcltr\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}
{\*\pnseclvl7\pnlcrm\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl8\pnlcltr\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl9\pnlcrm\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}\pard\plain \ltrpar
\ql \li0\ri0\sa160\sl259\slmult1\widctlpar\wrapdefault\hyphpar0\faauto\rin0\lin0\itap0 \rtlch\fcs1 \af37\afs22\alang1025 \ltrch\fcs0 \fs22\lang1029\langfe1033\loch\af37\hich\af37\dbch\af31505\cgrid\langnp1029\langfenp1033 {\rtlch\fcs1 \af31507\afs24 
\ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   message format: }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \b\cf6\lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37 PB}{\rtlch\fcs1 
\af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37  }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \b\lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37 TT TT}{\rtlch\fcs1 
\af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37  xx xx ...... xx}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 
\par }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   P \hich\f37 \endash \loch\f37  communication type configured}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 
\par }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   B - baudrate used}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 
\par }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   TTTT - timestamp (10ms internal ticks of particular DKEY)}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 
\par }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   xx xx ..... xx - received data}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 
\par \ltrrow}\trowd \irow0\irowband0\ltrrow\ts11\trleft0\trftsWidth1\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblind108\tblindtype3 \clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr
\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4531\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx4531\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 
\cltxlrtb\clftsWidth3\clwWidth4530\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9061\pard \ltrpar\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   Communication type}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 
\hich\af37\dbch\af31505\loch\f37   Meaning}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 
\ltrch\fcs0 \insrsid328988 \trowd \irow0\irowband0\ltrrow\ts11\trleft0\trftsWidth1\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblind108\tblindtype3 \clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 
\clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4531\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx4531\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr
\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4530\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9061\row \ltrrow}\pard \ltrpar\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   0}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 
\hich\af37\dbch\af31505\loch\f37   Key -> Car, Channel 1}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 
\af31507\afs24 \ltrch\fcs0 \insrsid328988 \trowd \irow1\irowband1\ltrrow\ts11\trleft0\trftsWidth1\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblind108\tblindtype3 \clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb
\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4531\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx4531\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 
\clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4530\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9061\row \ltrrow}\pard \ltrpar\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 
\ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   1}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 
\hich\af37\dbch\af31505\loch\f37   Key -> Car, Channe\hich\af37\dbch\af31505\loch\f37 l 2}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1
\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \trowd \irow2\irowband2\ltrrow\ts11\trleft0\trftsWidth1\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblind108\tblindtype3 
\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4531\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx4531\clvertalt\clbrdrt
\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4530\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9061\row \ltrrow}\pard \ltrpar
\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   2}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{
\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   Car -> Key, Channel 1}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1
\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \trowd \irow3\irowband3\ltrrow\ts11\trleft0\trftsWidth1\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblind108\tblindtype3 
\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4531\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx4531\clvertalt\clbrdrt
\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4530\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9061\row \ltrrow}\pard \ltrpar
\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   3}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{
\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   Car -> Key, Channel 2}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1
\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \trowd \irow4\irowband4\ltrrow\ts11\trleft0\trftsWidth1\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblind108\tblindtype3 
\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4531\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx4531\clvertalt\clbrdrt
\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth4530\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9061\row \ltrrow}\pard \ltrpar
\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   4}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{
\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   Car -> Key, LF}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1
\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \trowd \irow5\irowband5\lastrow \ltrrow
\ts11\trleft0\trftsWidth1\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblind108\tblindtype3 \clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 
\cltxlrtb\clftsWidth3\clwWidth4531\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx4531\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 
\cltxlrtb\clftsWidth3\clwWidth4530\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9061\row }\pard \ltrpar\ql \li0\ri0\sa160\sl259\slmult1\widctlpar\wrapdefault\hyphpar0\faauto\rin0\lin0\itap0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\lang1033\langfe1033\langnp1033\insrsid328988 
\par \ltrrow}\trowd \irow0\irowband0\ltrrow\ts11\trleft0\trftsWidth3\trwWidth9498\trftsWidthB3\trftsWidthA3\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblrsid328988\tblind108\tblindtype3 \clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 
\clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3019\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx3019\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb
\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3021\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx6040\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 
\clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3458\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9498\pard \ltrpar\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   Baudrate used}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 
\hich\af37\dbch\af31505\loch\f37   Baudrate}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37 
  Possible type of communication}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\insrsid328988 \trowd \irow0\irowband0\ltrrow\ts11\trleft0\trftsWidth3\trwWidth9498\trftsWidthB3\trftsWidthA3\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblrsid328988\tblind108\tblindtype3 \clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl
\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3019\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx3019\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 
\clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3021\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx6040\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb
\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3458\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9498\row \ltrrow}\pard \ltrpar\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 
\af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   1}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   8 kBit/s}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 
\hich\af37\dbch\af31505\loch\f37   RKE, KI, PING}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 
\af31507\afs24 \ltrch\fcs0 \insrsid328988 \trowd \irow1\irowband1\ltrrow\ts11\trleft0\trftsWidth3\trwWidth9498\trftsWidthB3\trftsWidthA3\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblrsid328988\tblind108\tblindtype3 \clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 
\clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3019\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx3019\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl
\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3021\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx6040\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 
\clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3458\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9498\row \ltrrow}\pard \ltrpar\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {
\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   2}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   19.2 kBit/s}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 
\hich\af37\dbch\af31505\loch\f37   CACG, SDS}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 \af31507\afs24 
\ltrch\fcs0 \insrsid328988 \trowd \irow2\irowband2\ltrrow\ts11\trleft0\trftsWidth3\trwWidth9498\trftsWidthB3\trftsWidthA3\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblrsid328988\tblind108\tblindtype3 \clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl
\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3019\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx3019\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 
\clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3021\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx6040\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb
\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3458\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9498\row \ltrrow}\pard \ltrpar\ql \li0\ri0\widctlpar\intbl\wrapdefault\hyphpar0\faauto\rin0\lin0 {\rtlch\fcs1 
\af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   3}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   2 kBit/s}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 
\hich\af37\dbch\af31505\loch\f37   THS, KI_35UP}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 \cell }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\intbl\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0 {\rtlch\fcs1 
\af31507\afs24 \ltrch\fcs0 \insrsid328988 \trowd \irow3\irowband3\lastrow \ltrrow\ts11\trleft0\trftsWidth3\trwWidth9498\trftsWidthB3\trftsWidthA3\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\tblrsid328988\tblind108\tblindtype3 \clvertalt\clbrdrt
\brdrs\brdrw10\brdrcf1 \clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3019\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx3019\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 
\clbrdrl\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3021\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx6040\clvertalt\clbrdrt\brdrs\brdrw10\brdrcf1 \clbrdrl
\brdrs\brdrw10\brdrcf1 \clbrdrb\brdrs\brdrw10\brdrcf1 \clbrdrr\brdrs\brdrw10\brdrcf1 \cltxlrtb\clftsWidth3\clwWidth3458\clpadt108\clpadr108\clpadft3\clpadfr3\clshdrawnil \cellx9498\row }\pard \ltrpar\ql \li0\ri0\sa160\sl259\slmult1
\widctlpar\wrapdefault\hyphpar0\faauto\rin0\lin0\itap0 {\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 
\par \hich\af37\dbch\af31505\loch\f37   Example: 03 7a 01 2d 18 25 8d 21 07 d2 fe 80}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \insrsid328988 
\par }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   03  -  message was sent from key to car, used channel 1, baudrate used 2kBit/s}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\insrsid328988 
\par }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   7a 01 \hich\f37 \endash \loch\f37  time from the beginning of measurement 0x017a*10ms = 3780ms}{\rtlch\fcs1 \af31507\afs24 
\ltrch\fcs0 \insrsid328988 
\par }{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 \lang1033\langfe1033\langnp1033\insrsid328988 \hich\af37\dbch\af31505\loch\f37   2d 18 25 8d 21 07 d2 fe 80 \hich\f37 \endash \loch\f37  message bytes received}{\rtlch\fcs1 \af31507\afs24 \ltrch\fcs0 
\insrsid328988 
\par }{\*\themedata 504b030414000600080000002100828abc13fa0000001c020000130000005b436f6e74656e745f54797065735d2e786d6cac91cb6ac3301045f785fe83d0b6d8
72ba28a5d8cea249777d2cd20f18e4b12d6a8f843409c9df77ecb850ba082d74231062ce997b55ae8fe3a00e1893f354e9555e6885647de3a8abf4fbee29bbd7
2a3150038327acf409935ed7d757e5ee14302999a654e99e393c18936c8f23a4dc072479697d1c81e51a3b13c07e4087e6b628ee8cf5c4489cf1c4d075f92a0b
44d7a07a83c82f308ac7b0a0f0fbf90c2480980b58abc733615aa2d210c2e02cb04430076a7ee833dfb6ce62e3ed7e14693e8317d8cd0433bf5c60f53fea2fe7
065bd80facb647e9e25c7fc421fd2ddb526b2e9373fed4bb902e182e97b7b461e6bfad3f010000ffff0300504b030414000600080000002100a5d6a7e7c00000
00360100000b0000005f72656c732f2e72656c73848fcf6ac3300c87ef85bd83d17d51d2c31825762fa590432fa37d00e1287f68221bdb1bebdb4fc7060abb08
84a4eff7a93dfeae8bf9e194e720169aaa06c3e2433fcb68e1763dbf7f82c985a4a725085b787086a37bdbb55fbc50d1a33ccd311ba548b63095120f88d94fbc
52ae4264d1c910d24a45db3462247fa791715fd71f989e19e0364cd3f51652d73760ae8fa8c9ffb3c330cc9e4fc17faf2ce545046e37944c69e462a1a82fe353
bd90a865aad41ed0b5b8f9d6fd010000ffff0300504b0304140006000800000021006b799616830000008a0000001c0000007468656d652f7468656d652f7468
656d654d616e616765722e786d6c0ccc4d0ac3201040e17da17790d93763bb284562b2cbaebbf600439c1a41c7a0d29fdbd7e5e38337cedf14d59b4b0d592c9c
070d8a65cd2e88b7f07c2ca71ba8da481cc52c6ce1c715e6e97818c9b48d13df49c873517d23d59085adb5dd20d6b52bd521ef2cdd5eb9246a3d8b4757e8d3f7
29e245eb2b260a0238fd010000ffff0300504b0304140006000800000021000cc90327a8060000611b0000160000007468656d652f7468656d652f7468656d65
312e786d6cec594f6f1c3514bf23f11dacb9b7d94d76d36cd44d95ddec1248d346d96d518fde19ef8c1bcf78647b93ee0db547242444412051094e1c1050a995
b89413e293048aa048fd0a3cdb33b3e3eca449da082ae81e9219fbe7f7ff3d3f7b2e5fb91333b44f84a43c697bf58b350f91c4e7014dc2b67763d8bfb0e221a9
701260c613d2f6a6447a57d6de7eeb325e5511890982f5895cc56d2f522a5d5d58903e0c637991a72481b931173156f02ac28540e003a01bb385c55a6d7921c6
34f150826320bbcd15dd47120753747d3ca63ef1d6720e3d066c1225f580cfc440d327d9b22d9cf884fdfcf52f5f187cb057d72839955d26d03e666d0f1806fc
6048ee280f312c154cb4bd9af9790b6b9717f06ab688a963d696d6f5cd2f5b972d08f6160d4f118e0aa6f57ea37569a3a06f004ccde37abd5eb7572fe81900f6
7dd0d6ca52a6d9e8afd43b39cd12c83eced3eed69ab5868b2fd15f9a93b9d5e9749aad4c164bd480ec63630ebf525b6eac2f3a7803b2f8e61cbed159ef76971d
bc0159fcf21cbe7fa9b5dc70f10614319aeccda1b543fbfd8c7a011973b659095f01f84a2d83cf50100d45846916639ea817c55b8c6f73d107900633ac6882d4
342563ec434877713c12146b267895e0d28c1df2e5dc90e687a42f68aadade7b2986f498d17bfee4bbe74f1ea1c3bb8f0feffe7878efdee1dd1f2c2167d5264e
c2f2aa67df7cfcd7830fd09f8fbe7a76ffd36abc2ce37ffbfec35f7ffaa41a08293413e7e9670f7f7ffcf0e9e71ffdf1edfd0af8bac0a3327c486322d1357280
76790c8a19abb892939138db8a61846979c57a124a9c60cda5827e4f450efada14b3cc3b8e1c1de25af0a6801252057c6772db1178108989a2159cb7a2d8016e
73ce3a5c545a614bf32a99793849c26ae66252c6ed62bc5fc5bb8b13c7bfbd490af5330f4b47f16e441c3177184e140e494214d2737c8f900aed6e51ead8759b
fa824b3e56e816451d4c2b4d32a423279a668b36690c7e9956e90cfe766cb37d137538abd27a83ecbb48c80acc2a841f12e698f11d3c5138ae2239c4312b1bfc
2a5651959083a9f0cbb89e54e0e990308e7a0191b26acd7501fa969cbe85a16a55ba7d9b4d63172914ddaba27915735e466ef0bd6e84e3b40a3ba04954c6be2b
f7204431dae1aa0abecddd0cd1efe0079c1cebee9b9438ee3eb91adca0a123d22c40f4cc44685f42b9762a704c9317956346a11edb1838bf720c05f0e9970f2a
22eb752dc4ebb0275565c2e691f27b1cee68d1ed7211d0d7bfe66ee049b24320cce7379e3725f74dc9f5fef325f7b87c3e6da19dd55628bbba6fb08db16993e3
1776c963cad8404d19b92a4da32c61af08fa30a8d79ae322294e4e69048f596d7770a1c0660d125cbd4f553488700a4d76ddd3444299910e254ab984039e19ae
a4adf1d0a82b7b3c6cea8383ad0912ab6d1ed8e1253d9c9f0f0a3266c709cd413467b4a4099c96d9d2a58c28a8fd32ccea5aa85373ab1bd14cb973b8152a831f
e75583c1c29ad08420685dc0cacb7060d7ace170821909b4ddedfe9bbbc578e13c5d24231c90cc475aef791fd58d93f25831b702103b153ed287bd13ac56e2d6
d2645f81db699c5466d738865deebd57f1521ec1332fe9dc3d928e2c2927274bd041db6b35179b1ef271daf6c670ae85c73805af4bddf76116c24d91af840dfb
1393d964f9cc9bad5c313709ea705d61ed3ea7b053075221d50696910d0d339585004b34272bff6213cc7a5e0ad8487f092996562018fe3529c08eae6bc9784c
7c5576766944dbcebe66a5944f141183283840233611bb18dcaf4315f409a884eb095311f40bdca7696b9b29b738674957bec532383b8e591ae1acdcea14cd33
d9c24d1e173298b79278a05ba5ec46b9b3ab6252fe9c542987f1ff4c15bd9fc06dc152a03de0c3bdaec048e76bdbe342451caa501a51bf2fa07930b503a205ee
64611a820a6e97cd7f41f6f57f9b739686496b38f4a95d1a2241613f5291206407ca9289be1388d5b3bdcb9264192113512571656ac51e917dc286ba062eebbd
dd431184baa926591930b8a3f1e7be6719340a759353ce37a786147bafcd817fbaf3b1c90c4ab975d83434b9fd0b112b7655bbde2ccff7deb2227a62d66635f2
ac0066a5ada095a5fd4b8a70c6add656ac398d179bb970e0c5798d61b0688852b8f341fa0fec7f54f8cc7ea5d01bea90ef426d45f0c1411383b081a8be601b0f
a40ba41d1c41e364076d306952d6b459eba4ad966fd6e7dce9167c8f185b4b761a7f9fd1d84573e6b27372f13c8d9d59d8b1b51d3bd6d4e0d9a3290a43e3fc30
631c63be7195bf40f1d16d70f406dcf14f98922698e0db92c0d07a0e4c1e40f25b8e66e9dadf000000ffff0300504b0304140006000800000021000dd1909fb6
0000001b010000270000007468656d652f7468656d652f5f72656c732f7468656d654d616e616765722e786d6c2e72656c73848f4d0ac2301484f78277086f6f
d3ba109126dd88d0add40384e4350d363f2451eced0dae2c082e8761be9969bb979dc9136332de3168aa1a083ae995719ac16db8ec8e4052164e89d93b64b060
828e6f37ed1567914b284d262452282e3198720e274a939cd08a54f980ae38a38f56e422a3a641c8bbd048f7757da0f19b017cc524bd62107bd5001996509aff
b3fd381a89672f1f165dfe514173d9850528a2c6cce0239baa4c04ca5bbabac4df000000ffff0300504b01022d0014000600080000002100828abc13fa000000
1c0200001300000000000000000000000000000000005b436f6e74656e745f54797065735d2e786d6c504b01022d0014000600080000002100a5d6a7e7c00000
00360100000b000000000000000000000000002b0100005f72656c732f2e72656c73504b01022d00140006000800000021006b799616830000008a0000001c00
000000000000000000000000140200007468656d652f7468656d652f7468656d654d616e616765722e786d6c504b01022d00140006000800000021000cc90327
a8060000611b00001600000000000000000000000000d10200007468656d652f7468656d652f7468656d65312e786d6c504b01022d0014000600080000002100
0dd1909fb60000001b0100002700000000000000000000000000ad0900007468656d652f7468656d652f5f72656c732f7468656d654d616e616765722e786d6c2e72656c73504b050600000000050005005d010000a80a00000000}
{\*\colorschememapping 3c3f786d6c2076657273696f6e3d22312e302220656e636f64696e673d225554462d3822207374616e64616c6f6e653d22796573223f3e0d0a3c613a636c724d
617020786d6c6e733a613d22687474703a2f2f736368656d61732e6f70656e786d6c666f726d6174732e6f72672f64726177696e676d6c2f323030362f6d6169
6e22206267313d226c743122207478313d22646b3122206267323d226c743222207478323d22646b322220616363656e74313d22616363656e74312220616363
656e74323d22616363656e74322220616363656e74333d22616363656e74332220616363656e74343d22616363656e74342220616363656e74353d22616363656e74352220616363656e74363d22616363656e74362220686c696e6b3d22686c696e6b2220666f6c486c696e6b3d22666f6c486c696e6b222f3e}
{\*\latentstyles\lsdstimax267\lsdlockeddef0\lsdsemihiddendef1\lsdunhideuseddef1\lsdqformatdef0\lsdprioritydef99{\lsdlockedexcept \lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority0 \lsdlocked0 Normal;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority9 \lsdlocked0 heading 1;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 2;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 3;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 4;
\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 5;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 6;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 7;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 8;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 9;
\lsdpriority39 \lsdlocked0 toc 1;\lsdpriority39 \lsdlocked0 toc 2;\lsdpriority39 \lsdlocked0 toc 3;\lsdpriority39 \lsdlocked0 toc 4;\lsdpriority39 \lsdlocked0 toc 5;\lsdpriority39 \lsdlocked0 toc 6;\lsdpriority39 \lsdlocked0 toc 7;
\lsdpriority39 \lsdlocked0 toc 8;\lsdpriority39 \lsdlocked0 toc 9;\lsdqformat1 \lsdpriority35 \lsdlocked0 caption;\lsdunhideused0 \lsdlocked0 List;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority10 \lsdlocked0 Title;
\lsdunhideused0 \lsdlocked0 Default Paragraph Font;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority11 \lsdlocked0 Subtitle;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority22 \lsdlocked0 Strong;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority20 \lsdlocked0 Emphasis;\lsdsemihidden0 \lsdunhideused0 \lsdpriority59 \lsdlocked0 Table Grid;\lsdunhideused0 \lsdlocked0 Placeholder Text;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority1 \lsdlocked0 No Spacing;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 1;
\lsdunhideused0 \lsdlocked0 Revision;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority34 \lsdlocked0 List Paragraph;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority29 \lsdlocked0 Quote;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority30 \lsdlocked0 Intense Quote;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority19 \lsdlocked0 Subtle Emphasis;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority21 \lsdlocked0 Intense Emphasis;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority31 \lsdlocked0 Subtle Reference;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority32 \lsdlocked0 Intense Reference;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority33 \lsdlocked0 Book Title;\lsdpriority37 \lsdlocked0 Bibliography;
\lsdqformat1 \lsdpriority39 \lsdlocked0 TOC Heading;}}{\*\datastore 0105000002000000180000004d73786d6c322e534158584d4c5265616465722e352e3000000000000000000000060000
d0cf11e0a1b11ae1000000000000000000000000000000003e000300feff090006000000000000000000000001000000010000000000000000100000feffffff00000000feffffff0000000000000000ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
fffffffffffffffffdfffffffeffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffff52006f006f007400200045006e00740072007900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000016000500ffffffffffffffffffffffffec69d9888b8b3d4c859eaf6cd158be0f00000000000000000000000090c0
71cf5db6d501feffffff00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffffffffffffffffffffffff00000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffffffffffffffffffffffff0000000000000000000000000000000000000000000000000000
000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffffffffffffffffffffffff000000000000000000000000000000000000000000000000
0000000000000000000000000000000000000000000000000105000000000000}}";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
