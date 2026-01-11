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
    [HarmonyPatch(typeof(Need_Food), "NeedInterval")]\
    public static class NoHungerMod\
    \{\
        public static bool Prefix()\
        \{\
            return false; // \uc0\u1055 \u1088 \u1086 \u1089 \u1090 \u1086  \u1086 \u1090 \u1082 \u1083 \u1102 \u1095 \u1072 \u1077 \u1084  \u1091 \u1084 \u1077 \u1085 \u1100 \u1096 \u1077 \u1085 \u1080 \u1077  \u1091 \u1088 \u1086 \u1074 \u1085 \u1103  \u1077 \u1076 \u1099  \u1089 \u1086  \u1074 \u1088 \u1077 \u1084 \u1077 \u1085 \u1077 \u1084 \
        \}\
    \}\
\}}