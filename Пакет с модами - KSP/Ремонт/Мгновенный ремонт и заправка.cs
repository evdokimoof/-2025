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
    public class QuickFix : MonoBehaviour\
    \{\
        void Update()\
        \{\
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.R))\
            \{\
                Vessel v = FlightGlobals.ActiveVessel;\
                if (v == null) return;\
\
                foreach (Part p in v.parts)\
                \{\
                    p.RestoreToFullHealth(); // \uc0\u1063 \u1080 \u1085 \u1080 \u1084  \u1076 \u1077 \u1090 \u1072 \u1083 \u1080 \
                    foreach (PartResource res in p.Resources) res.amount = res.maxAmount; // \uc0\u1047 \u1072 \u1087 \u1088 \u1072 \u1074 \u1083 \u1103 \u1077 \u1084 \
                \}\
                ScreenMessages.PostScreenMessage("\uc0\u1050 \u1086 \u1088 \u1072 \u1073 \u1083 \u1100  \u1082 \u1072 \u1082  \u1085 \u1086 \u1074 \u1077 \u1085 \u1100 \u1082 \u1080 \u1081 !", 3f, ScreenMessageStyle.UPPER_CENTER);\
            \}\
        \}\
    \}\
\}}