{\rtf1\ansi\ansicpg1251\cocoartf2865
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\paperw11900\paperh16840\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 using HarmonyLib;\
using RimWorld;\
using Verse;\
\
namespace RimWorldNanoPack\
\{\
    [HarmonyPatch(typeof(Need_Mood), "MoodLevel", MethodType.Getter)]\
    public static class GodMoodMod\
    \{\
        public static void Postfix(ref float __result)\
        \{\
            __result = 1f; // \uc0\u1042 \u1089 \u1077 \u1075 \u1076 \u1072  100% \u1089 \u1095 \u1072 \u1089 \u1090 \u1100 \u1103 \
        \}\
    \}\
\}}