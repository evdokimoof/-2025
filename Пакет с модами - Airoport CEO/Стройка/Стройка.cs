{\rtf1\ansi\ansicpg1251\cocoartf2865
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\paperw11900\paperh16840\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 using HarmonyLib;\
\
namespace AirportCEONanoPack\
\{\
    [HarmonyPatch(typeof(Structure), "Construct")]\
    public static class InstantBuildMod\
    \{\
        public static void Postfix(Structure __instance)\
        \{\
            // \uc0\u1059 \u1089 \u1090 \u1072 \u1085 \u1072 \u1074 \u1083 \u1080 \u1074 \u1072 \u1077 \u1084  \u1089 \u1090 \u1072 \u1090 \u1091 \u1089  "\u1047 \u1072 \u1074 \u1077 \u1088 \u1096 \u1077 \u1085 \u1086 " \u1089 \u1088 \u1072 \u1079 \u1091  \u1087 \u1086 \u1089 \u1083 \u1077  \u1085 \u1072 \u1095 \u1072 \u1083 \u1072  \u1089 \u1090 \u1088 \u1086 \u1081 \u1082 \u1080 \
            __instance.SetCondition(1f);\
            __instance.InternalBuildCompletion();\
        \}\
    \}\
\}}