﻿using HarmonyLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using TheOtherRoles.Patches;
using UnityEngine;

namespace TheOtherRoles
{
    public class ModTranslation
    {
        public static int defaultLanguage = (int)SupportedLangs.English;
        public static Dictionary<string, Dictionary<int, string>> stringData;

        public ModTranslation() { 

        }

        public static void Load()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("TheOtherRoles.Resources.stringData.json");
            var byteArray = new byte[stream.Length];
            var read = stream.Read(byteArray, 0, (int)stream.Length);
            string json = System.Text.Encoding.UTF8.GetString(byteArray);

            stringData = new Dictionary<string, Dictionary<int, string>>();
            JObject parsed = JObject.Parse(json);

            for (int i = 0; i < parsed.Count; i++)
            {
                JProperty token = parsed.ChildrenTokens[i].TryCast<JProperty>();
                if (token == null) continue;

                string stringName = token.Name;
                var val = token.Value.TryCast<JObject>();

                if (token.HasValues)
                {
                    var strings = new Dictionary<int, string>();

                    for (int j = 0; j < (int)SupportedLangs.Irish + 1; j++)
                    {
                        string key = j.ToString();
                        var text = val[key]?.TryCast<JValue>().Value.ToString();

                        if (text != null && text.Length > 0)
                        {
                            //TheOtherRolesPlugin.Instance.Log.LogInfo($"key: {stringName} {key} {text}");
                            strings[j] = text;
                        }
                    }

                    stringData[stringName] = strings;
                }
            }

            //TheOtherRolesPlugin.Instance.Log.LogInfo($"Language: {stringData.Keys}");
        }

        public static string getString(string key)
        {
            // Strip out color tags.
            string keyClean = Regex.Replace(key, "<.*?>", "");
            keyClean = Regex.Replace(keyClean, "^-\\s*", "");
            keyClean = keyClean.Trim();

            if (!stringData.ContainsKey(keyClean))
            {
                return key;
            }

            var data = stringData[keyClean];
            int lang = (int)SaveManager.LastLanguage;

            if (data.ContainsKey(lang))
            {
                string cleanedText = key.Replace(keyClean, data[lang]);
                if (TheOtherRolesPlugin.UnifiedTranslation.Value)
                {
                    cleanedText = Regex.Replace(cleanedText, "魔女", "ウィッチ");
                    cleanedText = Regex.Replace(cleanedText, "魔術", "スペル");
                    cleanedText = Regex.Replace(cleanedText, "弁護士", "ローヤー");
                    cleanedText = Regex.Replace(cleanedText, "依頼人", "クライアント");
                    cleanedText = Regex.Replace(cleanedText, "追跡者", "パスーアー");
                    cleanedText = Regex.Replace(cleanedText, "『空包』", "『ブランク』");
                    cleanedText = Regex.Replace(cleanedText, "空包", "ブランク(空包)");
                    cleanedText = Regex.Replace(cleanedText, "幽霊", "ゴースト");
                    cleanedText = Regex.Replace(cleanedText, "警備員", "セキュリティガード");
                    cleanedText = Regex.Replace(cleanedText, "守護天使", "ガーディアンエンジェル");
                }
                return cleanedText;
            }
            else if (data.ContainsKey(defaultLanguage))
            {
                return key.Replace(keyClean, data[defaultLanguage]);
            }

            return key;
        }

        public static Sprite getImage(string key, float pixelsPerUnit)
        {
            key = getString(key);
            key = key.Replace("/", ".");
            key = key.Replace("\\", ".");
            key = "TheOtherRoles.Resources." + key;

            return Helpers.loadSpriteFromResources(key, pixelsPerUnit);
        }
    }

    [HarmonyPatch(typeof(LanguageSetter), nameof(LanguageSetter.SetLanguage))]
    class SetLanguagePatch
    {
        static void Postfix()
        {
            ClientOptionsPatch.updateTranslations();
        }
    }
}