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
namespace FirstPersonCameraMod\
\{\
    public class ModInfo : IUserMod\
    \{\
        public string Name => "FPC & Follow (Mac OS)";\
        public string Description => "Tab - \uc0\u1089 \u1074 \u1086 \u1073 \u1086 \u1076 \u1085 \u1099 \u1081  \u1087 \u1086 \u1083 \u1077 \u1090 , Option+1 - \u1074 \u1080 \u1076  \u1086 \u1090  \u1083 \u1080 \u1094 \u1072  \u1078 \u1080 \u1090 \u1077 \u1083 \u1103 /\u1072 \u1074 \u1090 \u1086 .";\
    \}\
\
    public class CameraController : ThreadingExtensionBase\
    \{\
        private bool isFreeLook = false;\
        private bool isFollowing = false;\
        private InstanceID targetInstance;\
        \
        private float rotationX = 0;\
        private float rotationY = 0;\
        private Vector3 freePos;\
\
        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)\
        \{\
            // 1. \uc0\u1055 \u1077 \u1088 \u1077 \u1082 \u1083 \u1102 \u1095 \u1077 \u1085 \u1080 \u1077  \u1089 \u1074 \u1086 \u1073 \u1086 \u1076 \u1085 \u1086 \u1075 \u1086  \u1087 \u1086 \u1083 \u1077 \u1090 \u1072  \u1085 \u1072  TAB\
            if (Input.GetKeyDown(KeyCode.Tab))\
            \{\
                isFreeLook = !isFreeLook;\
                isFollowing = false; // \uc0\u1057 \u1073 \u1088 \u1072 \u1089 \u1099 \u1074 \u1072 \u1077 \u1084  \u1089 \u1083 \u1077 \u1078 \u1082 \u1091  \u1087 \u1088 \u1080  \u1087 \u1077 \u1088 \u1077 \u1093 \u1086 \u1076 \u1077  \u1074  \u1087 \u1086 \u1083 \u1077 \u1090 \
                if (isFreeLook) \{\
                    freePos = Camera.main.transform.position;\
                    Cursor.visible = false;\
                \} else \{\
                    Cursor.visible = true;\
                \}\
            \}\
\
            // 2. \uc0\u1055 \u1077 \u1088 \u1077 \u1082 \u1083 \u1102 \u1095 \u1077 \u1085 \u1080 \u1077  \u1089 \u1083 \u1077 \u1078 \u1082 \u1080  \u1085 \u1072  Option (Alt) + 1\
            if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyDown(KeyCode.Alpha1))\
            \{\
                if (isFollowing) \{\
                    isFollowing = false;\
                \} else \{\
                    // \uc0\u1055 \u1099 \u1090 \u1072 \u1077 \u1084 \u1089 \u1103  \u1079 \u1072 \u1093 \u1074 \u1072 \u1090 \u1080 \u1090 \u1100  \u1074 \u1099 \u1076 \u1077 \u1083 \u1077 \u1085 \u1085 \u1099 \u1081  \u1086 \u1073 \u1098 \u1077 \u1082 \u1090 \
                    InstanceID hovered = ToolManager.instance.m_properties.m_hoverInstance;\
                    if (!hovered.IsEmpty) \{\
                        targetInstance = hovered;\
                        isFollowing = true;\
                        isFreeLook = false;\
                    \}\
                \}\
            \}\
\
            // \uc0\u1051 \u1054 \u1043 \u1048 \u1050 \u1040  \u1050 \u1040 \u1052 \u1045 \u1056 \u1067 \
            if (isFreeLook)\
            \{\
                UpdateFreeLook();\
            \}\
            else if (isFollowing)\
            \{\
                UpdateFollowing();\
            \}\
        \}\
\
        private void UpdateFreeLook()\
        \{\
            // \uc0\u1042 \u1088 \u1072 \u1097 \u1077 \u1085 \u1080 \u1077  \u1084 \u1099 \u1096 \u1100 \u1102 \
            rotationX += Input.GetAxis("Mouse X") * 2f;\
            rotationY -= Input.GetAxis("Mouse Y") * 2f;\
            Camera.main.transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);\
\
            // \uc0\u1044 \u1074 \u1080 \u1078 \u1077 \u1085 \u1080 \u1077  (WASD)\
            float speed = 0.5f;\
            if (Input.GetKey(KeyCode.W)) freePos += Camera.main.transform.forward * speed;\
            if (Input.GetKey(KeyCode.S)) freePos -= Camera.main.transform.forward * speed;\
            if (Input.GetKey(KeyCode.A)) freePos -= Camera.main.transform.right * speed;\
            if (Input.GetKey(KeyCode.D)) freePos += Camera.main.transform.right * speed;\
            \
            Camera.main.transform.position = freePos;\
        \}\
\
        private void UpdateFollowing()\
        \{\
            Vector3 targetPos = Vector3.zero;\
            Quaternion targetRot = Quaternion.identity;\
\
            if (targetInstance.Type == InstanceType.Vehicle) \{\
                VehicleManager.instance.m_vehicles.m_buffer[targetInstance.Vehicle].GetSmoothPosition(targetInstance.Vehicle, out targetPos, out targetRot);\
            \} else if (targetInstance.Type == InstanceType.Citizen) \{\
                ushort instanceID = CitizenManager.instance.m_citizens.m_buffer[targetInstance.Citizen].m_instance;\
                CitizenManager.instance.m_instances.m_buffer[instanceID].GetSmoothPosition(instanceID, out targetPos, out targetRot);\
            \} else \{\
                isFollowing = false; return;\
            \}\
\
            // \uc0\u1057 \u1084 \u1077 \u1097 \u1077 \u1085 \u1080 \u1077  \u1082 \u1072 \u1084 \u1077 \u1088 \u1099  (\u1095 \u1091 \u1090 \u1100  \u1074 \u1099 \u1096 \u1077  \u1086 \u1073 \u1098 \u1077 \u1082 \u1090 \u1072 )\
            Camera.main.transform.position = targetPos + Vector3.up * 1.5f + targetRot * Vector3.forward * 0.5f;\
            Camera.main.transform.rotation = targetRot;\
        \}\
    \}\
\}}