{\rtf1\ansi\ansicpg1251\cocoartf2865
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\paperw11900\paperh16840\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 using UnityEngine;\
\
namespace KSPNanoPack\
\{\
    [KSPAddon(KSPAddon.Startup.Flight, false)]\
    public class GodMode : MonoBehaviour\
    \{\
        void FixedUpdate()\
        \{\
            Vessel v = FlightGlobals.ActiveVessel;\
            if (v == null) return;\
\
            foreach (Part p in v.parts)\
            \{\
                p.crashTolerance = 1000f; // \uc0\u1042 \u1099 \u1076 \u1077 \u1088 \u1078 \u1080 \u1090  \u1091 \u1076 \u1072 \u1088  \u1085 \u1072  \u1086 \u1075 \u1088 \u1086 \u1084 \u1085 \u1086 \u1081  \u1089 \u1082 \u1086 \u1088 \u1086 \u1089 \u1090 \u1080 \
                p.temperature = 0; // \uc0\u1053 \u1077  \u1089 \u1075 \u1086 \u1088 \u1080 \u1090  \u1074  \u1072 \u1090 \u1084 \u1086 \u1089 \u1092 \u1077 \u1088 \u1077 \
            \}\
        \}\
    \}\
\}}