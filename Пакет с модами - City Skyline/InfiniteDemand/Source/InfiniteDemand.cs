{\rtf1\ansi\ansicpg1251\cocoartf2865
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\paperw11900\paperh16840\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 using ICities;\
using UnityEngine;\
\
namespace InfiniteDemandMod\
\{\
    public class ModInfo : IUserMod\
    \{\
        public string Name => "Infinite Demand (Mac OS)";\
        public string Description => "\uc0\u1059 \u1089 \u1090 \u1072 \u1085 \u1072 \u1074 \u1083 \u1080 \u1074 \u1072 \u1077 \u1090  \u1089 \u1087 \u1088 \u1086 \u1089  \u1085 \u1072  \u1074 \u1089 \u1077  \u1079 \u1086 \u1085 \u1099  \u1085 \u1072  100%";\
    \}\
\
    public class DemandExtension : DemandModifierBase\
    \{\
        public override int OnCalculateResidentialDemand(int demand)\
        \{\
            return 100;\
        \}\
\
        public override int OnCalculateCommercialDemand(int demand)\
        \{\
            return 100;\
        \}\
\
        public override int OnCalculateWorkplaceDemand(int demand)\
        \{\
            return 100;\
        \}\
    \}\
\}}