{\rtf1\ansi\ansicpg1251\cocoartf2865
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\paperw11900\paperh16840\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 using HarmonyLib;\
using UnityEngine;\
\
namespace AirportCEONanoPack\
\{\
    [HarmonyPatch(typeof(Employee), "SetEnergyLevel")]\
    public static class StaffEnergyMod\
    \{\
        public static void Prefix(ref float amount)\
        \{\
            amount = 1f; // \uc0\u1069 \u1085 \u1077 \u1088 \u1075 \u1080 \u1103  \u1074 \u1089 \u1077 \u1075 \u1076 \u1072  \u1085 \u1072  100%\
        \}\
    \}\
\
    [HarmonyPatch(typeof(Employee), "SetStressLevel")]\
    public static class StaffStressMod\
    \{\
        public static void Prefix(ref float amount)\
        \{\
            amount = 0f; // \uc0\u1057 \u1090 \u1088 \u1077 \u1089 \u1089  \u1074 \u1089 \u1077 \u1075 \u1076 \u1072  \u1085 \u1072  0%\
        \}\
    \}\
\}}