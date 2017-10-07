﻿//using QuantRiskLib;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AIRA.UI.Models
//{
//    public class QuantRiskLibModel
//    {
//        public int Id { get; set; }
//        public double Mean { get; set; }
//        public double Volatility { get; set; }
//        public double Skew { get; set; }
//        public double ExcessKurtosis { get; set; }
//        public double Beta { get; set; }
//        public double RSquared { get; set; }


//        public static SecurityReturns goog, gs, msft, spy;

//        public static void Sample1()
//        {
//            InitializeSecurityReturns();
//            List<SecurityReturns> srList = new List<SecurityReturns> { goog, gs, msft, spy };
//            foreach (SecurityReturns sr in srList)
//            {
//                //Statistics are annualized using 256 days per year
//                double mean = 256 * Moments.Mean(sr.returns);
//                double vol = 16 * Moments.StandardDeviation(sr.returns);
//                double skew = Moments.Skewness(sr.returns) / 16;
//                double exKurt = Moments.ExcessKurtosis(sr.returns) / 256;
//                Regression regression = new Regression(sr.returns, spy.returns, true, true);

//                Console.WriteLine("Summary stats for: {0}", sr.tkr);
//                Console.WriteLine("   mean = {0}", mean.ToString("0.00%"));
//                Console.WriteLine("    vol = {0}", vol.ToString("0.00%"));
//                Console.WriteLine("   skew = {0}", skew.ToString("0.00%"));
//                Console.WriteLine(" exKurt = {0}", exKurt.ToString("0.00%"));
//                Console.WriteLine("   beta = {0} ({1})", regression.Betas[1].Value.ToString("0.00"), regression.Betas[1].pValue.ToString("0.00%"));
//                Console.WriteLine("    R^2 = {0}", regression.rSquared.ToString("0.00%"));
//                Console.WriteLine();
//            }
//            Console.ReadLine();
//        }

//        public class SecurityReturns
//        {
//            public string tkr;
//            public double[] returns;

//            public SecurityReturns(string tkr)
//            {
//                this.tkr = tkr;
//            }
//        }

//        public static void InitializeSecurityReturns()
//        {
//            //dividend adjusted returns from 1/3/2011 through 4/24/2012
//            goog = new SecurityReturns("GOOG");
//            gs = new SecurityReturns("GS");
//            msft = new SecurityReturns("MSFT");
//            spy = new SecurityReturns("SPY");
//            goog.returns = new double[] { -0.00368991478447922, 0.0115425496578756, 0.00727338401168987, 0.00479217603911989, -0.00361754590876649, 0.00293059377086006, 0.00139608123244755, -0.000291795678181708, 0.0121454863870014, 0.0247524752475248, -0.0123196222816316, -0.00788286505738032, -0.0238364950460296, -0.00122583070460749, 0.0144498265366236, -0.00550079850300845, 0.000470397404703915, -0.0256164983219572, -0.00104827035391603, 0.0177893264041574, 0.00157109190887673, -0.0030228758169935, 0.00136032123248388, 0.00541752594192927, 0.00665809308307157, -0.00304020181765257, -9.73236009731475E-05, 0.013075076244241, 0.00584467574059244, -0.00636790575499483, 0.000112152527437395, 0.00166607926692506, 0.00770879314205299, -0.0315356780091417, 0.0018190459022304, -0.00408951122161879, 0.00200387635097387, 0.00550783555176712, -0.0206064558200195, 4.99367467873572E-05, 0.0145974466951846, -0.0146663166874466, -0.0149179181512438, 0.00109860392793154, -0.000911684759669706, -0.0193825303749768, -0.00618645528175068, -0.0116523035841238, -0.000754399199986076, -0.0218765362736146, 0.0076467420570813, -0.00053441641727246, 0.0275193383951806, 0.00142237640936696, 0.00838356544031026, 0.00812491411295867, -0.0121828622058648, -0.00755511091178804, 0.0110713292547275, 0.000189091159128829, 0.00845593290251609, 0.00858954257277245, -0.00696181142277797, -0.0316328614211815, 0.00894410374457453, 0.0101361942248076, -0.0031724137931035, -0.00136640376366397, -0.0117082633320055, 0.0099367343719878, 0.0038696466995211, -0.0826433423795612, -0.00727341247409085, -0.010078961354491, 0.00805322800222431, -0.00119833374545869, -9.52199581033483E-05, 0.0147985906104182, 0.00927142374535479, 0.000390508777149726, 0.0113946874361024, -0.0101819518470871, -0.00867127153891852, 0.00355878551761595, -0.00283693238022356, 0.00192786418851886, 0.00444610498785727, 0.00926201458116355, -0.0132864040098771, -0.00074703520403416, -0.010279413138959, -0.0210178453403833, 0.0232244126384014, -0.00122535158164629, 0.0027179554934789, -0.0135905882352942, -0.010762742591073, -0.000250776442446798, 0.00272064214872838, -0.0029634190928858, 0.00534614864995268, 0.0155884046842004, -0.00646478394011561, 0.00468036529680351, -0.00943074650607867, -0.00386174198975318, -0.00389590450236052, 0.000269733926747946, -0.00469980931101555, -0.0139724807926771, -0.00938156267786692, 0.00721177659342616, -0.0106615260538584, -0.00512973456606021, -0.0306772987988889, -0.000907179085398536, 0.0173758718890586, -0.0121501014198783, -0.0139422188456088, -0.0111199033776187, 0.016677897574124, 0.0224730737365368, 0.00794084877949968, 0.0177060514098519, 0.0289308424503337, 0.0218989309636683, 0.0054841860115693, 0.0209952181709504, -0.026728869374314, -0.00885354987875719, 0.0127636170535579, 0.00795865245969177, -0.0173150522052538, 0.129844594850077, -0.0044844550048525, 0.0127912058358824, -0.0119492158327109, 0.0195515243134291, 0.0185176032554078, 0.00121314074050111, 0.00571908623865062, -0.0245775236136991, 0.00612628042554598, -0.0118669591121878, 0.00510195630207545, -0.0236827793068214, 0.0148041863605672, -0.0393399537568408, 0.00263194348247677, -0.0570254213871235, 0.0501629976923922, -0.0425524493817687, 0.0238975610644615, 0.00291747460551827, -0.0116004753711619, -0.0327153957970677, -0.0108534322820038, -0.0530244771640251, -0.0276501346854698, 0.014768190336511, 0.0414517132705704, 0.00861570486874044, -0.00621070534502857, 0.0131143758172449, 0.0231940173860229, 0.00300511983379091, 0.000480858146846663, -0.0156388642413488, -0.0143849765258215, -0.00506821126438549, 0.0226933241411008, 0.0017414751980227, -0.0188986092418125, 0.0100409640849766, -0.00113181921074478, 0.00481568212720968, 0.0197154509744956, 0.00759363019758184, -1.82922367746962E-05, -7.31702855469728E-05, -0.0135923750983297, -0.0343842729970328, 0.00931510006530178, 0.012140587239063, 0.014006655511478, -0.0194682389587273, -0.00253384766659109, -0.0236208530805688, -0.0378999689344517, 0.0128753632547627, 0.00557880055788008, 0.0198335644937588, 0.000796565056050918, 0.0428055598695449, 0.0111882644228084, 0.00979417504326384, 0.0191248860528715, 0.0584804737115153, -0.0156672525689562, 0.0139077282326884, -0.0166127584630234, 0.00511451696228675, 0.0116846848390358, 0.0100425070703991, -0.0222326548405486, 0.00540160504835719, 0.0210809981068036, 0.00245544289842489, -0.0124970840137301, -0.0236062365010799, 0.010662749503154, 0.0216818850244519, -0.00227615062761509, 0.0204482168618111, 0.00659181694146268, -0.0186007773459189, -0.00976786754305683, 0.0222995227532432, 0.00764362620202182, 0.00580750407830334, -0.00825548202932386, -0.0173352740118076, -0.00996887845956698, -0.0234332974717589, -0.00161806727028618, -0.017051724137931, -0.0124712774727684, 0.0447424511545294, -0.00894268858702138, 0.0282366664951195, 0.0239910575752014, 0.0107369209964645, 0.00852730672512729, -0.00300487493007272, -0.000609198903441967, -0.011774330675821, 0.0184562941319698, -0.00323547225144237, 0.000383760533427156, -0.0120838195099339, 0.00237837138188217, 0.0103625270361883, -0.0065978656783181, 0.0137336571088561, -0.00721798308929669, 0.00619986577610175, 0.00546291885024605, 0.0112297438165335, -0.00085903943771957, 0.00422072846646855, 0.00544831880448319, 0.0302059142282087, 0.00431313025052224, -0.0138714311366493, -0.0136416746331619, -0.0423986954247561, 0.00109243967483846, 0.00452546779214952, 0.00587896990223009, -0.00738517247951207, 0.00574409190547054, 0.00688854242896676, 0.0105228231502111, -0.0837750363525494, -0.000802061468625791, -0.00783918568110403, -0.0196925619265659, -0.00244078034732829, 0.0209118113008273, -0.00394841201420732, 0.00418909795911295, 0.00124114392098055, 0.00736876538746272, 0.0191758814581874, 0.02139754833733, -0.00380896090889696, 0.00507605847355677, 0.00263999344101011, -0.00907663624766962, 0.0103810796983052, -0.00398562561254501, -0.00688795591708221, 0.00158530946561866, -0.00309965046494756, 0.0154802857898915, -0.00986970684039079, -0.00301016547685634, 0.00625299038128387, -0.000967371700278786, 0.0149021023780999, -0.000226394346609723, 0.0067124949454104, -0.0018476863753213, -0.0112676056338028, -0.0151241351241351, 0.00304152340650608, 0.000560316413975003, -0.0113482886978291, 0.00816326530612241, 0.0208708584648434, -0.00289747159182875, 0.00834429130343023, 0.00629497850691477, 0.0143030846025855, -0.000772895044007712, 0.0102448341725994, 0.00948467139598102, -0.00535562262982729, 0.0104888031248541, -0.00355751312891759, 0.0135080832122655, -0.0112083689154569, -0.01105781835567, 0.00885783793899312, -0.00664688060347486, -0.0116242880707106, -0.00445564039990542, -0.00234058704453444, -0.00630904825312285, 0.0145167980091249, 0.0236650103780111, -0.0405677332145435, -0.0296669868715978, 0.00577491048888742, -0.00347786144331251, -0.013416742118693, -0.00540630735858503, 0.00258363252021622, 0.00614123159303875 };
//            gs.returns = new double[] { 0.00393137955682628, -0.00320398718405126, 0.0292857142857143, -0.0076335877862595, -0.0132867132867134, -0.00389794472005668, 0.0156527926004981, -0.0126094570928196, 0.00390209294075911, 0.0127208480565371, -0.00662944870900214, -0.00421496311907262, -0.0116402116402117, 0.012847965738758, 0.00246652572233969, 0.0115992970123023, 0.00312717164697706, -0.0387945964669207, -0.000720720720720705, 0.00937612693833386, -0.00178635226866728, -0.0103793843951325, 0.00433996383363476, 0.0154843356139719, 0.00283687943262418, -0.010961810466761, -0.0168037182695745, -0.00909090909090909, -0.000733944954128425, -0.00403966213734849, 0.00222551928783378, 0.00703182827535164, -0.00551267916207285, -0.0173688100517368, 0, 0.00676946220383602, -0.00821815465072838, 0.00112994350282477, -0.0158013544018058, -0.00305810397553524, 0.00460122699386507, -0.00954198473282443, -0.0088631984585742, 0.00738724727838263, -0.000771902740254711, -0.018539976825029, 0.0106257378984652, 0.000389408099688534, -0.0116776956014014, -0.0236313509255613, -0.000403388463089875, 0.000807102502017739, 0.0213709677419354, -0.00118436636399517, 0.00948616600790508, 0.0105716523101018, -0.00736148779542804, -0.00819672131147544, 0.00314836678473035, 0.00470772852098866, -0.00859039437719636, 0.00354470263883418, 0.00274725274725276, 0.00900195694716244, 0.0143522110162916, 0.00191204588910137, -0.00496183206106866, -0.00345224395857307, -0.0130869899923018, -0.000390015600624086, -0.00819352321498234, -0.00196695515342253, -0.0114308238076469, 0.00279106858054228, 0.0242544731610339, -0.00931677018633548, 0.00352664576802507, 0.0226474033580633, 0.00725467735777005, 0.0125094768764216, -0.0295769374766005, -0.0100308641975309, 0.00584567420109114, 0.00968616815187912, -0.0103607060629317, 0.00310197751066312, -0.00154619250096647, -0.00619434765776216, -0.0120763537202962, -0.00157728706624602, -0.0114533965244865, -0.0183779464642429, 0.00447700447700445, 0.00693311582381736, 0.00121506682867548, -0.00930420711974112, -0.013066557778685, -0.000827472072817672, 0.00165631469979307, 0.0198429102935097, 0.00364815565464126, 0.0100969305331179, -0.0231907237105159, -0.00859598853868198, -0.0127993393889347, 0.00418235048097036, 0.00208246563931683, -0.00498753117206972, 0.000835421888053449, -0.0104340567612688, 0.0139181779839729, 0.00748752079866887, -0.0198183319570603, 0.0109519797809605, 0.0108333333333334, 0.00865622423742775, 0.011851246424193, -0.00444264943457201, -0.000811359026369151, -0.0133982947624847, 0.037037037037037, 0.0238095238095239, -0.0069767441860465, 0.0148321623731459, 0.000769230769230753, 0.000384319754035417, 0.0115251632731463, 0.0167109760729207, 0.00560328726186037, -0.010772659732541, -0.00337964701464513, 0.00339110776186887, -0.00600826135936914, 0.0117113713638082, -0.00709484690067219, 0.0357277171869123, -0.0174291938997822, 0.00147819660014792, 0.0158671586715867, 0.0138031238648746, 0.00609100680759578, -0.0267094017094017, 0.0142700329308452, -0.0115440115440116, -0.00474452554744522, -0.0172350568390172, 0.00447761194029854, -0.0364041604754829, -0.010023130300694, -0.0467289719626168, 0.0449346405228757, -0.053948397185301, 0.040909090909091, -0.00357284636760619, 0.0163346613545817, 0, -0.00394477317554246, -0.0229702970297029, -0.0251317389541954, -0.00291060291060292, 0.030859049207673, 0.00728155339805824, -0.0132530120481927, 0.0276760276760277, 0.0233663366336634, 0.015092879256966, 0.0141059855127717, -0.0146616541353384, -0.015642884395269, -0.0112403100775193, 0.0192081536652293, 0.00846153846153842, -0.0183066361556064, 0.00582750582750591, 0.0057937427578215, 0.0176651305683564, 0.0184905660377358, 0.00481659874027427, 0.00331858407079645, -0.00845277471517826, -0.0366938472942921, -0.0357829934590227, 0, 0.0151636073423784, 0.00904088050314467, -0.00350603817686028, -0.00508209538702107, -0.0220039292730844, -0.0144636400160707, 0.0330207908683244, 0.0217048145224941, 0.0173812282734646, -0.00341685649202733, 0.0262857142857143, 0.00222717149220485, -0.00148148148148145, 0.00816023738872399, 0.00331125827814569, -0.0106343967730106, 0.0122312824314306, -0.00659099231050896, -0.0033173608551419, 0.00443786982248524, 0.00110456553755527, -0.0139757263699891, -0.00820589332338675, 0.0248213614140654, -0.00990825688073393, -0.0129725722757599, -0.0240330454374766, 0.000769526741054372, 0.0199923106497501, -0.0105540897097626, 0.020952380952381, 0.0134328358208955, -0.0353460972017673, 0.00305343511450389, 0.023972602739726, -0.00557413600891857, 0.006726457399103, -0.0250560957367239, -0.0203298810893748, -0.00939702427564598, -0.0118577075098814, -0.00840000000000003, -0.0129084308188786, -0.00694728238659576, 0.0234567901234568, -0.00120627261761163, 0.0297906602254428, -0.0117279124315871, -0.00237341772151908, 0.0190325138778747, -0.001556420233463, -0.00233826968043643, -0.00781250000000011, 0.0118110236220473, -0.00739299610894933, 0.00980007840062721, -0.00659937888198764, -0.00117233294255573, 0.0172143974960877, -0.018076923076923, 0.0195848021934978, -0.0103726469458317, 0.00194099378881977, 0.00852382797365372, 0.000384172109104803, -0.00844854070660518, 0.00774593338497286, -0.0023059185242121, 0.0312018489984591, 0.0235338064998132, 0.0102189781021898, 0.0155346820809248, -0.0131625755958734, 0.00360490266762803, -0.00431034482758624, 0.0101010101010101, 0.00892857142857143, 0.000353982300885011, -0.00106157112526543, -0.00389656393907189, 0.0565433854907539, 0.000673174015482988, -0.0131180625630676, 0.00749829584185409, -0.00202976995940456, -0.00915254237288134, 0.0130003421142661, -0.00270178993583243, 0.0121909922113105, 0.00200736032117761, 0.0096828046744574, -0.00132275132275129, 0.00496688741721861, 0.0102141680395387, 0.00358773646444877, -0.00877478063048422, 0.00262295081967208, -0.00425114453891429, -0.00661157024793386, 0.0412645590682196, -0.00127836369447105, 0.00608000000000004, -0.0054071246819339, 0.00319795330988172, 0.00350653490596109, -0.00412960609911052, 0.0165869218500797, -0.0040790712268592, 0.0173282923755514, -0.00650356147414063, -0.00872817955112212, -0.00754716981132082, 0.00887198986058305, 0.00533919597989944, -0.000624804748516075, 0.00156298843388561, 0.0196629213483147, 0.00306091215182129, 0.0024412572474824, -0.0076103500761035, -0.0122699386503067, -0.00652173913043492, -0.00250078149421689, 0.0028204324663115, 0.000312499999999938, 0.0181193377069667, -0.00214789812826021, -0.0101476014760149, -0.00217458838148494, 0.00435865504358657, 0.000929944203347834, -0.0108392691235676, -0.0228553537883532, 0.00993271387375837, -0.0133248730964466, -0.0202572347266882, -0.00393829996718075, 0.0207578253706754, -0.00548741123305364, 0.00876338851022394, 0.0115830115830117, -0.00954198473282445, -0.00417469492613998, 0.0454692034827475, -0.00925354719309082, -0.00622665006226637 };
//            msft.returns = new double[] { 0.000173360300491194, 0.00531546105847, -0.010287356321839, -0.00882643284362122, -0.00544847384146703, -0.00235626767200741, 0.0136395843174302, -0.000582512960913347, 0.0199918400652795, -0.00182857142857139, -0.0468857339134417, -0.00480509339900301, 0.00307803729856956, 0.00060168471720832, -0.0259771497294048, -0.00413631312507709, 0.0168619428429732, -0.0137779674449795, 0.0114359893676207, 0.0104510451045105, -0.00169358253190589, -0.00248409572856725, 0.0011540330417883, 0.0139537705514772, 0.00849638006342378, -0.0150697122515575, -0.0040359014517197, 0.00798354905044147, 0.00516020640825641, 0.00232808022922628, 0.00536001429337148, -0.00977430247023284, 0.00526441732471881, -0.0303499166865032, 0.000920584264146346, 0.00214605432583233, 0.0102790014684288, -0.00599563953488378, -0.0150812064965197, 0.0023557126030624, 0.0173170882553034, -0.0212170952641498, -0.0114906832298136, 0.0135092679861766, 0.00650960942343449, -0.012811826301201, 0.00255818306607598, -0.0140029873039582, -0.00744808432746328, -0.0182511923688395, 0.00887420650343312, 0.0270304975922954, 0.00156289072268067, 0.00362024842394347, -0.00783630822812358, 0.00238199711652978, -0.012131824151085, -0.00949547382414383, 0.0127820029398607, 0.00378620559096355, -0.0029546740428742, 0.0102774274905422, -0.00830056793359536, 6.29326620515475E-05, 0.0187527531307028, 0.00315028723207128, -0.00886699507389161, 0.00316848906560631, -0.00650275592989417, -0.00155840917591323, -0.0273459449335081, -0.00423647217408047, -0.00870237865016434, -0.0124853687085446, 0.0055314105096798, 0.00530451866404717, -0.00859878835255028, 0.00709639266706099, -0.00267501794219349, -0.0147847703781239, 0.00272244355909692, 0.00192040262234303, 0.00376734963648376, -0.00230460262066237, -0.00732576557550167, -0.00206103317598565, -0.0065289806795469, 0.00858369098712447, -0.0167553191489362, -0.0346902894238571, -0.00903677758318733, -0.00607945709034366, 0.00149359886201997, 0.00021305305020951, -0.0106503834138029, -0.0312186019807664, 0.00629676272316464, 0.00368080094228504, -0.000733460466480815, 0.000146799765120242, 0.0201820049904594, 0.0149286023366508, -0.0324024728202942, -0.0131453330395828, 0.00706950439053443, -0.0105667627281461, -0.00679611650485434, -0.0105271073013009, 0.0147427616080249, 0.0178985995656406, 0.011845203060624, -0.00312659056205924, -0.0164113785557987, 0.00919540229885064, 0.00837680946432498, -0.015229905997231, 0.00606778155986401, -0.0105913503971756, -0.016057091882248, -0.0109549712904202, -0.00152776716828347, -0.0110932598883025, 0.0252978492959927, 0.00422545838678037, 0.0267488165902773, -0.0157336260519576, -0.00453531598513021, 0.00836507580849955, -0.0068883786386192, -0.0153639618138425, -0.0129525829419785, -0.00299286317243508, -0.00023091133004927, 0.00207868196165995, -0.00637676705593104, -0.0064950127580608, 0.0331543310763483, 0.0213182674199624, -0.000663814721935414, 0.0100376411543286, 0.00548045305078553, -0.0209302325581395, 0.00831353919239908, -0.00640459363957601, -0.00607542416833365, -0.0217666790905704, 0.00647717747466298, -0.0442913385826772, -0.00831814940980747, -0.0600734941683976, 0.0430902600713922, -0.100953312148619, 0.0703280768533622, -0.0138018628281117, 0.0228384991843393, -0.0189708721564676, 0.00325147599897318, -0.0350533049040512, -0.012197277709033, -0.0469756621331424, 0.0032860764247488, 0.0322852330151601, -0.00426071978968361, 0.0173889293517844, 0.0386577181208053, -0.00465236495218396, 0.00902934537246043, -0.0349337463431423, -0.0454707560627674, -0.0233513917429479, 0.0361514919663351, -0.0327672143252723, -0.0242389540986736, 0.00655256723716383, 0.0113680528565877, 0.00432318186185035, 0.0328104074995216, -0.00444567935537653, -0.0249325518652897, -0.0209903635149318, -0.0462917844264692, -0.0396484774167177, 0.0127686741859971, 0.0416053792813616, 0.00413556586645145, -0.0324460070316424, 0.0368563122923589, -0.0532692500250326, -0.0472765732416711, 0.049955595026643, -0.00306618735462034, 0.0386043058648849, -0.0535076074747269, 0.0372208436724566, 0.00582483877678388, 0.0249224405377456, -0.0298658056704671, 0.00603224128965157, 0.00175746924428824, 0.0552115583075335, -0.0142787286063569, 0.000694513344577767, 0.0121951219512196, 0.018513076697032, -0.0340450086555107, 0.058641975308642, 0.0947051631712594, -0.00463917525773201, -0.0544622820645607, -0.0548607941579187, 0.0250144871547227, 0.0146047300480544, -0.024517087667162, 0.00504569687737992, 0.0285118878469263, -0.0820593111070178, -0.00170562857429519, 0.0217085427135678, -0.0233130041314184, 0.0046328935441635, -0.0416040100250627, -0.0339958158995816, -0.00476448294531671, -0.00663692742900663, -0.0208105147864183, -0.0168903803131992, 0.00978495847081579, 0.0228732394366197, -0.0178453403833444, 0.0793829523702285, -0.0149175881493844, 0.029863390871545, 0.0264267352185089, 0.0134241634942898, 0.0392447607750099, -0.0495576904784552, 0.0153122497998399, -0.0337111877772302, -0.0305008670815056, -0.0188341750841751, -0.0144772117962466, -0.0195865070729055, -0.0266370699223085, 0.037400228050171, 0.0112112552209276, 0.026304347826087, -0.00667231518746024, -0.0201514020684508, -0.0193688792165397, 0.00987572126054151, -0.00637292605208217, 0.0545173062036934, -0.00650167785234904, -0.00168883259446904, -0.0122647494184817, 0.0135945193748662, 0.0384412292744746, 0.0145428658598597, 0.0145348837209301, -0.0222310048414188, -0.0129345189975746, 0.0678746928746928, 0.03230754481833, 0.00984398216939068, -0.00505793636196429, 0.00628523893150944, -0.00551116009920096, 0.0026784889627783, 0.0295689019896831, -0.0182517670215621, 0.0158571038002369, 0.0177626267157083, -0.000528867342441624, 0.0365111561866126, -0.00119118522930316, -0.0120112445693841, 0.001465769960338, -0.00232458028411546, -0.0151881256472212, 0.00359270942867154, -0.0144940190343141, 0.00265792504651366, 0.0138729345232835, 0.0101969670559526, 0.00621171598654127, -0.0194632598816771, 0.012591815320042, 0.000604490500863622, 0.00310693018037455, 0.0105824658005678, -0.0168217914780975, 0.052023623414973, -0.00965904400231158, -0.0110870290096699, -0.0418106718368035, 0.024016891000264, 0.00661512027491405, 0.00102415294017244, -0.00255776281012884, 0.0645354303786649, -0.0334832182431348, 0.022347761070034, -0.00105639525434744, 0.0111445538111119, 0.0138374899436846, -0.000238057451198232, -0.00992142233510596, 0.0115440115440116, 0.0149786019971468, -0.0135863199812602, 0.00023747328425553, -0.0205761316872428, 0.00492889463477698, 0.00426147784835572, -0.0175340272217775, -0.0224105614864314, -0.0163387795931977, -0.00830508474576275, -0.0210220475132455, 0.0119587988826816, 0.0384714914172345, -0.0440235899991693, 0.0229385698149275, -0.00738979019791051, -0.0130925894232415, -0.0150004335385416, -0.0102112676056338, -0.00613660618996796, 0.0211185682326622 };
//            spy.returns = new double[] { -0.00055096418732777, 0.00519766892424001, -0.00195863365716076, -0.00196247743150954, -0.00125845524618528, 0.00354386517561823, 0.0090245625049047, -0.00163322445170328, 0.00724468333722838, 0.0017014694508894, -0.00980543545398402, -0.00132553606237807, 0.00226420986883192, 0.00568668692062, 0.000542215336948049, 0.00387086784857165, 0.00246780288424479, -0.0174628817601355, 0.00751644221735052, 0.0160087037612683, -0.00191219213706593, 0.00222239252049959, 0.0028291787735128, 0.00625238276782305, 0.00454648783814499, -0.0022629554197781, 0.000378014666968949, 0.00597037484885142, 0.00240402674479748, -0.00314771790451934, 0.00631531463799717, 0.0029884198729922, 0.0020856610800745, -0.0200698728908049, -0.00614427672001822, -0.000686918027782044, 0.0106927365767968, 0.0061966296380261, -0.0166729252722493, 0.00213854731535936, 0.0172242969285877, -0.00749232037161909, -0.0078508341511285, 0.00874990489233817, -0.00143309699803912, -0.0185059294508648, 0.0069262736647684, -0.00603790889636191, -0.0114571318723569, -0.0185127566894835, 0.013235061023934, 0.00362143136488089, 0.0154978083907327, -0.00346847541236332, 0.00286178358728443, 0.00956347370044739, 0.00305576776165016, -0.0024371667936026, 0.00671858298976961, 0.00690125891096615, -0.0013557279505913, 0.00422354627045782, 0.000826135936913145, -0.000150082545399833, 0.00315220654458111, -0.00254376776896606, -0.0034503450345033, -0.00301068794219483, -0.00747395440132877, -0.000076062980147493, 0.000760687661646085, 0.00364852538765574, -0.0112087246289003, 0.00574448529411765, 0.0136318635290533, 0.00510894064613078, -0.00104649424428177, 0.00860520802155048, 0.00652867423399359, 0.00324316355863512, 0.00235103960032322, -0.00153925089789642, -0.00359712230215834, -0.00663081116923287, -0.00904843135800637, 0.00441583713793859, 0.00387481371087936, 0.00853622327790978, -0.0105247663207478, 0.00476048795001499, -0.00769914124963, -0.00634139062966275, -0.000150161423530372, 0.00893594653450496, 0.00238166120869301, -0.00794475794475789, -0.011600928074246, -0.000832954717552731, 0.0033345964380447, 0.00460759876123585, 0.00383458646616535, 0.0104112051531722, -0.0224610822831727, -0.00106165162660207, -0.00994458361800655, -0.0105811992025763, -0.000619962802231743, -0.00418734491315152, 0.00763121009188614, -0.0139103554868625, 0.000783699059561195, 0.0126859827721221, -0.0177853386947108, 0.00220437726342309, 0.00296936370777691, 0.00511609602518698, 0.013703993735317, -0.00602549246813442, -0.00287557317167931, -0.0116134060795012, 0.00891096916646949, 0.0130529935907458, 0.00856415400046281, 0.009562423500612, 0.0147760854739713, -0.000821385902030953, 0.00119572528211641, 0.0103754571919087, -0.00709219858156034, -0.0180803571428572, -0.00431916344623773, 0.00334855403348552, -0.00690230582524269, 0.00580462842740389, -0.00820107828992318, 0.0162315289794042, -0.000602727341218896, 0.0138710893328308, 0.000669194735668105, -0.00557289344627731, -0.00373608309048793, -0.0204755118877973, -0.00290964777947929, -0.00683458762094906, -0.00425268692492083, -0.0255474452554745, 0.00541875846681016, -0.0468415629705952, -0.00149675702644276, -0.0651232511658894, 0.0464991982896846, -0.0441777323799796, 0.0448837830617151, 0.00673314582800653, 0.0211649170335252, -0.00853921406068646, 0.00066895225353289, -0.0431185760842316, -0.016330451488953, 0.000799005681818212, 0.0329104941009491, 0.0140845070422535, -0.0152439024390244, 0.0145338837289301, 0.0287361193523777, 0.00263678312458806, 0.00443786982248514, -0.0104729176894125, -0.0255498594344303, -0.00729741196436147, 0.0282075391059066, -0.010391553745116, -0.0262096774193549, 0.00646997929606625, 0.00917116653809885, 0.0138440631900799, 0.0172572673200972, 0.00588816602157613, -0.00995720868992753, -0.00116366054359572, -0.0294582674544396, -0.0323244448255166, 0.00602516391990082, 0.0237801655804121, 0.0111837577426016, -0.0204185809086269, 0.00790342192113945, -0.0249892287806979, -0.0284577993813522, 0.0219230419357773, 0.0185152216485668, 0.018091242789722, -0.00669585372134948, 0.0334456831734509, 0.00100351229302563, 0.00877192982456138, -0.00198757763975151, 0.017094017094017, -0.0190911315982703, 0.0195458704150378, -0.0118290096263665, 0.00437546437711551, 0.0189873417721519, 0.0122610308945712, -0.0194437803809068, 0.0101584721657863, 0.0348350764279968, -0.000233227085438864, -0.0241057542768273, -0.0278884462151394, 0.016311475409836, 0.0182272763932576, -0.00609900990099007, 0.00621613006056743, 0.012830666877871, -0.0369096027525805, 0.00941864241636892, 0.0188223938223939, -0.00947418285172906, 0.00494181412402363, -0.0158629441624365, -0.0158768536428111, -0.00106461387273766, -0.0190195113953108, -0.00392779542035767, -0.0220656095310009, -0.00188743994509265, 0.0289668213855939, 0.00284019714309584, 0.0411495210329029, -0.00016001280102405, -0.000880211250700164, 0.0108921992631748, 0.000316906987799131, 0.00372247742753048, -0.0219364002209422, 0.0169423154497781, -0.0145973819912733, -0.00933902262297719, -0.010646078829744, 0.00361425989814368, 0.0014732362088721, -0.0106916687227568, 0.0302602045057777, 0.00193657709997575, 0.00885882258194406, 0.0089406881136745, 0.000791201835588214, -0.0131235670804016, 0.0103340543138669, -0.00491595306057726, 0.0159362549800797, 0.00156862745098041, 0.00266249021143296, -0.00257731958762885, 0.00242737452039791, 0.00867052023121376, 0.000542089367304214, 0.00239938080495358, -0.0051733456875916, 0.00388078236572493, 0.0110561311272615, 0.00527643955035557, 0.00372736954206588, -0.00257673361121618, -0.0011397310234785, 0.00836756427810737, -0.00512975256487633, -0.000454959053685186, -0.00341374601729623, -0.000380604399786948, 0.00875723423697842, 0.00158526458820871, 0.0140186915887849, -0.000668946038352932, 0.00252882112309411, 0.00296757919726987, 0.00125748945927965, -0.00738770685579196, 0.00744269127716582, -0.00125591016548475, -0.00466010799615353, 0.0110731272294888, 0.00264608599779482, 0.000439850450846729, -0.00322415182824062, 0.00441079173711677, 0.00219571104442664, 0.0016796903527349, 0.0029163021289006, -0.00392555975574289, 0.00518172529557714, -0.00304944456545406, -0.00407836282863595, -0.0146252285191956, 0.00697588126159553, 0.00994914879504749, 0.00386748394629306, 7.26902667734196E-05, 0.0180258758540485, -0.00107096958446384, 0.00578943606604247, 0.00137862421830598, 0.00392017106200986, -0.00291089811856583, -0.00163771005411556, -0.00720348049354553, 0.00323275862068978, 0.0140350877192983, -0.00310712520302257, -0.00495856060069412, -0.00170854986829935, 0.00413606218355568, 0.00731482139052625, -0.00408911449520595, -0.00991080277502462, -0.000500500500500655, -0.011231132412905, -0.0167848357690638, 0.00809418690213388, 0.0130656934306569, -0.0118884645867858, -0.000656263672159654, 0.014812112367749, -0.0033793500143802, -0.00642089315345224, 0.00167005518443211, -0.00840884378397968, 0.00380144747423065 };
//        }
//    }
//}
