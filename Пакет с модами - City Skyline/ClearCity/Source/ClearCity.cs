{\rtf1\ansi\ansicpg1251\cocoartf2865
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\paperw11900\paperh16840\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 using ICities;\
using UnityEngine;\
using ColossalFramework;\
\
namespace ClearCityMod\
\{\
    public class ModInfo : IUserMod\
    \{\
        public string Name => "Clear City (Auto-Bulldoze)";\
        public string Description => "\uc0\u1040 \u1074 \u1090 \u1086 \u1084 \u1072 \u1090 \u1080 \u1095 \u1077 \u1089 \u1082 \u1080  \u1091 \u1076 \u1072 \u1083 \u1103 \u1077 \u1090  \u1079 \u1072 \u1073 \u1088 \u1086 \u1096 \u1077 \u1085 \u1085 \u1099 \u1077  \u1080  \u1089 \u1075 \u1086 \u1088 \u1077 \u1074 \u1096 \u1080 \u1077  \u1079 \u1076 \u1072 \u1085 \u1080 \u1103  \u1085 \u1072  Mac OS.";\
    \}\
\
    // \uc0\u1050 \u1083 \u1072 \u1089 \u1089 , \u1082 \u1086 \u1090 \u1086 \u1088 \u1099 \u1081  \u1088 \u1072 \u1073 \u1086 \u1090 \u1072 \u1077 \u1090  \u1087 \u1086 \u1089 \u1090 \u1086 \u1103 \u1085 \u1085 \u1086  \u1074 \u1086  \u1074 \u1088 \u1077 \u1084 \u1103  \u1089 \u1080 \u1084 \u1091 \u1083 \u1103 \u1094 \u1080 \u1080 \
    public class ClearCityLogic : ThreadingExtensionBase\
    \{\
        private float timer = 0f;\
        private const float interval = 5f; // \uc0\u1055 \u1088 \u1086 \u1074 \u1077 \u1088 \u1082 \u1072  \u1082 \u1072 \u1078 \u1076 \u1099 \u1077  5 \u1089 \u1077 \u1082 \u1091 \u1085 \u1076 , \u1095 \u1090 \u1086 \u1073 \u1099  \u1085 \u1077  \u1085 \u1072 \u1075 \u1088 \u1091 \u1078 \u1072 \u1090 \u1100  \u1087 \u1088 \u1086 \u1094 \u1077 \u1089 \u1089 \u1086 \u1088  Mac\
\
        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)\
        \{\
            timer += realTimeDelta;\
            if (timer >= interval)\
            \{\
                timer = 0f;\
                ClearRuins();\
            \}\
        \}\
\
        private void ClearRuins()\
        \{\
            BuildingManager manager = Singleton<BuildingManager>.instance;\
            \
            // \uc0\u1055 \u1088 \u1086 \u1093 \u1086 \u1076 \u1080 \u1084  \u1087 \u1086  \u1074 \u1089 \u1077 \u1084  \u1079 \u1076 \u1072 \u1085 \u1080 \u1103 \u1084  \u1074  \u1075 \u1086 \u1088 \u1086 \u1076 \u1077 \
            for (ushort i = 0; i < manager.m_buildings.m_buffer.Length; i++)\
            \{\
                Building building = manager.m_buildings.m_buffer[i];\
\
                // \uc0\u1055 \u1088 \u1086 \u1074 \u1077 \u1088 \u1103 \u1077 \u1084  \u1089 \u1090 \u1072 \u1090 \u1091 \u1089 : \u1079 \u1072 \u1073 \u1088 \u1086 \u1096 \u1077 \u1085 \u1086  \u1080 \u1083 \u1080  \u1088 \u1072 \u1079 \u1088 \u1091 \u1096 \u1077 \u1085 \u1086 /\u1089 \u1075 \u1086 \u1088 \u1077 \u1083 \u1086 \
                if ((building.m_flags & Building.Flags.Abandoned) != Building.Flags.None ||\
                    (building.m_flags & Building.Flags.Collapsed) != Building.Flags.None)\
                \{\
                    // \uc0\u1059 \u1076 \u1072 \u1083 \u1103 \u1077 \u1084  \u1079 \u1076 \u1072 \u1085 \u1080 \u1077 \
                    manager.ReleaseBuilding(i);\
                \}\
            \}\
        \}\
    \}\
\}}