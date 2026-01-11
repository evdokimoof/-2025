{\rtf1\ansi\ansicpg1251\cocoartf2865
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\paperw11900\paperh16840\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 using ICities;\
using ColossalFramework;\
\
namespace UnlockEverythingMod\
\{\
    public class ModInfo : IUserMod\
    \{\
        public string Name => "Unlock All & Monuments (Mac OS)";\
        public string Description => "\uc0\u1056 \u1072 \u1079 \u1073 \u1083 \u1086 \u1082 \u1080 \u1088 \u1091 \u1077 \u1090  \u1074 \u1077 \u1093 \u1080 , \u1076 \u1086 \u1088 \u1086 \u1075 \u1080  \u1080  \u1074 \u1089 \u1077  \u1084 \u1086 \u1085 \u1091 \u1084 \u1077 \u1085 \u1090 \u1099 .";\
    \}\
\
    // \uc0\u1051 \u1086 \u1075 \u1080 \u1082 \u1072  \u1088 \u1072 \u1079 \u1073 \u1083 \u1086 \u1082 \u1080 \u1088 \u1086 \u1074 \u1082 \u1080  \u1074 \u1077 \u1093  (\u1101 \u1090 \u1072 \u1087 \u1086 \u1074  \u1088 \u1072 \u1079 \u1074 \u1080 \u1090 \u1080 \u1103  \u1075 \u1086 \u1088 \u1086 \u1076 \u1072 )\
    public class UnlockLogic : MilestonesExtensionBase\
    \{\
        public override void OnRefreshMilestones()\
        \{\
            milestonesManager.UnlockEverything();\
        \}\
    \}\
\
    // \uc0\u1051 \u1086 \u1075 \u1080 \u1082 \u1072  \u1088 \u1072 \u1079 \u1073 \u1083 \u1086 \u1082 \u1080 \u1088 \u1086 \u1074 \u1082 \u1080  \u1079 \u1076 \u1072 \u1085 \u1080 \u1081  (\u1074 \u1082 \u1083 \u1102 \u1095 \u1072 \u1103  \u1052 \u1086 \u1085 \u1091 \u1084 \u1077 \u1085 \u1090 \u1099  \u1080  \u1059 \u1085 \u1080 \u1082 \u1072 \u1083 \u1100 \u1085 \u1099 \u1077  \u1079 \u1076 \u1072 \u1085 \u1080 \u1103 )\
    public class UnlockBuildings : LoadingExtensionBase\
    \{\
        public override void OnLevelLoaded(LoadMode mode)\
        \{\
            // \uc0\u1055 \u1088 \u1086 \u1074 \u1077 \u1088 \u1103 \u1077 \u1084 , \u1095 \u1090 \u1086  \u1084 \u1099  \u1074  \u1089 \u1072 \u1084 \u1086 \u1081  \u1080 \u1075 \u1088 \u1077 , \u1072  \u1085 \u1077  \u1074  \u1088 \u1077 \u1076 \u1072 \u1082 \u1090 \u1086 \u1088 \u1077 \
            if (mode == LoadMode.NewGame || mode == LoadMode.LoadGame)\
            \{\
                UnlockAllServiceBuildings();\
            \}\
        \}\
\
        private void UnlockAllServiceBuildings()\
        \{\
            // \uc0\u1055 \u1086 \u1083 \u1091 \u1095 \u1072 \u1077 \u1084  \u1076 \u1086 \u1089 \u1090 \u1091 \u1087  \u1082 \u1086  \u1074 \u1089 \u1077 \u1084  \u1087 \u1088 \u1077 \u1092 \u1072 \u1073 \u1072 \u1084  \u1079 \u1076 \u1072 \u1085 \u1080 \u1081  \u1074  \u1080 \u1075 \u1088 \u1077 \
            int count = PrefabCollection<BuildingInfo>.PrefabCount();\
            for (uint i = 0; i < count; i++)\
            \{\
                BuildingInfo prefab = PrefabCollection<BuildingInfo>.GetPrefab(i);\
                if (prefab != null)\
                \{\
                    // \uc0\u1057 \u1085 \u1080 \u1084 \u1072 \u1077 \u1084  \u1073 \u1083 \u1086 \u1082 \u1080 \u1088 \u1086 \u1074 \u1082 \u1091  (\u1076 \u1077 \u1083 \u1072 \u1077 \u1084  \u1079 \u1076 \u1072 \u1085 \u1080 \u1077  \u1076 \u1086 \u1089 \u1090 \u1091 \u1087 \u1085 \u1099 \u1084 )\
                    prefab.m_UnlockMilestone = null;\
                \}\
            \}\
        \}\
    \}\
\}}