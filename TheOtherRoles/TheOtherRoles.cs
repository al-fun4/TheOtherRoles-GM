using System.Net;
using System.Linq;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using Hazel;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;
using TheOtherRoles.Objects;

namespace TheOtherRoles
{
    [HarmonyPatch]
    public static class TheOtherRoles
    {
        public static System.Random rnd = new System.Random((int)DateTime.Now.Ticks);
        public static Sprite blankIcon;

        public static Sprite getBlankIcon()
        {
            if (blankIcon) return blankIcon;
            blankIcon = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.BlankButton.png", 115f);
            return blankIcon;
        }

        public enum Teams
        {
            Crew,
            Impostor,
            Jackal,
            Jester,
            Arsonist,
            Lovers,
            Opportunist,
            Vulture,

            None = int.MaxValue,
        }
        
                public static void clearAndReloadRoles()
                {
                    CustomOverlays.resetOverlays();

/*                    Jester.clearAndReload();
                    Mayor.clearAndReload();
                    Engineer.clearAndReload();
                    Sheriff.clearAndReload();
                    Lighter.clearAndReload();
                    Godfather.clearAndReload();
                    Mafioso.clearAndReload();
                    Janitor.clearAndReload();
                    Detective.clearAndReload();
                    TimeMaster.clearAndReload();
                    Medic.clearAndReload();
                    Shifter.clearAndReload();
                    Swapper.clearAndReload();
                    //Lovers.clearAndReload();
                    Seer.clearAndReload();
                    Morphling.clearAndReload();
                    Camouflager.clearAndReload();
                    Hacker.clearAndReload();
                    Mini.clearAndReload();
                    Tracker.clearAndReload();
                    Vampire.clearAndReload();
                    Snitch.clearAndReload();
                    Jackal.clearAndReload();
                    Sidekick.clearAndReload();
                    Eraser.clearAndReload();
                    Spy.clearAndReload();
                    Trickster.clearAndReload();
                    Cleaner.clearAndReload();
                    Warlock.clearAndReload();
                    SecurityGuard.clearAndReload();
                    Arsonist.clearAndReload();
                    Guesser.clearAndReload();
                    BountyHunter.clearAndReload();
                    Bait.clearAndReload();
                    Madmate.clearAndReload();
                    GM.clearAndReload();
                    Opportunist.clearAndReload();
                    Vulture.clearAndReload();
                    Medium.clearAndReload();*/
                }
        /*
                public static class Jester
                {
                    public static PlayerControl jester;
                    public static Color color = new Color32(236, 98, 165, byte.MaxValue);

                    public static bool triggerJesterWin = false;
                    public static bool canCallEmergency = true;
                    public static bool canSabotage = true;

                    public static void clearAndReload()
                    {
                        jester = null;
                        triggerJesterWin = false;
                        canCallEmergency = CustomOptionHolder.jesterCanCallEmergency.getBool();
                        canSabotage = CustomOptionHolder.jesterCanSabotage.getBool();
                    }
                }

                public static class Mayor
                {
                    public static PlayerControl mayor;
                    public static Color color = new Color32(32, 77, 66, byte.MaxValue);

                    public static void clearAndReload()
                    {
                        mayor = null;
                    }
                }

                public static class Engineer
                {
                    public static PlayerControl engineer;
                    public static Color color = new Color32(0, 40, 245, byte.MaxValue);
                    public static bool usedRepair;
                    private static Sprite buttonSprite;

                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("RepairButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        engineer = null;
                        usedRepair = false;
                    }
                }

                public static class Godfather
                {
                    public static PlayerControl godfather;
                    public static Color color = Palette.ImpostorRed;

                    public static void clearAndReload()
                    {
                        godfather = null;
                    }
                }

                public static class Mafioso
                {
                    public static PlayerControl mafioso;
                    public static Color color = Palette.ImpostorRed;

                    public static void clearAndReload()
                    {
                        mafioso = null;
                    }
                }


                public static class Janitor
                {
                    public static PlayerControl janitor;
                    public static Color color = Palette.ImpostorRed;

                    public static float cooldown = 30f;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("CleanButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        janitor = null;
                        cooldown = CustomOptionHolder.janitorCooldown.getFloat();
                    }
                }

                public static class Lighter
                {
                    public static PlayerControl lighter;
                    public static Color color = new Color32(238, 229, 190, byte.MaxValue);

                    public static float lighterModeLightsOnVision = 2f;
                    public static float lighterModeLightsOffVision = 0.75f;

                    public static float cooldown = 30f;
                    public static float duration = 5f;

                    public static float lighterTimer = 0f;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("LighterButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        lighter = null;
                        lighterTimer = 0f;
                        cooldown = CustomOptionHolder.lighterCooldown.getFloat();
                        duration = CustomOptionHolder.lighterDuration.getFloat();
                        lighterModeLightsOnVision = CustomOptionHolder.lighterModeLightsOnVision.getFloat();
                        lighterModeLightsOffVision = CustomOptionHolder.lighterModeLightsOffVision.getFloat();
                    }
                }

                public static class Detective
                {
                    public static PlayerControl detective;
                    public static Color color = new Color32(45, 106, 165, byte.MaxValue);

                    public static float footprintIntervall = 1f;
                    public static float footprintDuration = 1f;
                    public static bool anonymousFootprints = false;
                    public static float reportNameDuration = 0f;
                    public static float reportColorDuration = 20f;
                    public static float timer = 6.2f;

                    public static void clearAndReload()
                    {
                        detective = null;
                        anonymousFootprints = CustomOptionHolder.detectiveAnonymousFootprints.getBool();
                        footprintIntervall = CustomOptionHolder.detectiveFootprintIntervall.getFloat();
                        footprintDuration = CustomOptionHolder.detectiveFootprintDuration.getFloat();
                        reportNameDuration = CustomOptionHolder.detectiveReportNameDuration.getFloat();
                        reportColorDuration = CustomOptionHolder.detectiveReportColorDuration.getFloat();
                        timer = 6.2f;
                    }
                }

                public static class TimeMaster
                {
                    public static PlayerControl timeMaster;
                    public static Color color = new Color32(112, 142, 239, byte.MaxValue);

                    public static bool reviveDuringRewind = false;
                    public static float rewindTime = 3f;
                    public static float shieldDuration = 3f;
                    public static float cooldown = 30f;

                    public static bool shieldActive = false;
                    public static bool isRewinding = false;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("TimeShieldButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        timeMaster = null;
                        isRewinding = false;
                        shieldActive = false;
                        rewindTime = CustomOptionHolder.timeMasterRewindTime.getFloat();
                        shieldDuration = CustomOptionHolder.timeMasterShieldDuration.getFloat();
                        cooldown = CustomOptionHolder.timeMasterCooldown.getFloat();
                    }
                }

                public static class Medic
                {
                    public static PlayerControl medic;
                    public static PlayerControl shielded;
                    public static PlayerControl futureShielded;

                    public static Color color = new Color32(126, 251, 194, byte.MaxValue);
                    public static bool usedShield;

                    public static int showShielded = 0;
                    public static bool showAttemptToShielded = false;
                    public static bool setShieldAfterMeeting = false;

                    public static Color shieldedColor = new Color32(0, 221, 255, byte.MaxValue);
                    public static PlayerControl currentTarget;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("ShieldButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        medic = null;
                        shielded = null;
                        futureShielded = null;
                        currentTarget = null;
                        usedShield = false;
                        showShielded = CustomOptionHolder.medicShowShielded.getSelection();
                        showAttemptToShielded = CustomOptionHolder.medicShowAttemptToShielded.getBool();
                        setShieldAfterMeeting = CustomOptionHolder.medicSetShieldAfterMeeting.getBool();
                    }
                }

                public static class Shifter
                {
                    public static PlayerControl shifter;
                    public static Color color = new Color32(102, 102, 102, byte.MaxValue);

                    public static PlayerControl futureShift;
                    public static PlayerControl currentTarget;
                    public static bool shiftModifiers = false;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("ShiftButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        shifter = null;
                        currentTarget = null;
                        futureShift = null;
                        shiftModifiers = CustomOptionHolder.shifterShiftsModifiers.getBool();
                    }
                }

                public static class Swapper
                {
                    public static PlayerControl swapper;
                    public static Color color = new Color32(134, 55, 86, byte.MaxValue);
                    private static Sprite spriteCheck;
                    public static bool canCallEmergency = false;
                    public static bool canOnlySwapOthers = false;

                    public static byte playerId1 = Byte.MaxValue;
                    public static byte playerId2 = Byte.MaxValue;

                    public static Sprite getCheckSprite()
                    {
                        if (spriteCheck) return spriteCheck;
                        spriteCheck = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.SwapperCheck.png", 150f);
                        return spriteCheck;
                    }

                    public static void clearAndReload()
                    {
                        swapper = null;
                        playerId1 = Byte.MaxValue;
                        playerId2 = Byte.MaxValue;
                        canCallEmergency = CustomOptionHolder.swapperCanCallEmergency.getBool();
                        canOnlySwapOthers = CustomOptionHolder.swapperCanOnlySwapOthers.getBool();
                    }
                }
        *//*
                public static class Lovers
                {
                    public static PlayerControl lover1;
                    public static PlayerControl lover2;
                    public static Color color = new Color32(232, 57, 185, byte.MaxValue);


                    public static bool hasTasks
                    {
                        get
                        {
                            return !separateTeam || tasksCount;
                        }
                    }

                    public static bool existing()
                    {
                        return lover1 != null && lover2 != null && !lover1.Data.Disconnected && !lover2.Data.Disconnected;
                    }

                    public static bool existingAndAlive()
                    {
                        return existing() && !lover1.Data.IsDead && !lover2.Data.IsDead && !notAckedExiledIsLover; // ADD NOT ACKED IS LOVER
                    }

                    public static bool existingWithKiller()
                    {
                        return existing() && (lover1.isRole(CustomRoleTypes.Jackal) || lover2.isRole(CustomRoleTypes.Jackal)
                                           || lover1 == Sidekick.sidekick || lover2 == Sidekick.sidekick
                                           || lover1.Data.Role.IsImpostor || lover2.Data.Role.IsImpostor);
                    }


                    public static void clearAndReload()
                    {
                        lover1 = null;
                        lover2 = null;
                        notAckedExiledIsLover = false;
                    }
                }*//*

                public static class Seer
                {
                    public static PlayerControl seer;
                    public static Color color = new Color32(97, 178, 108, byte.MaxValue);
                    public static List<Vector3> deadBodyPositions = new List<Vector3>();

                    public static float soulDuration = 15f;
                    public static bool limitSoulDuration = false;
                    public static int mode = 0;

                    private static Sprite soulSprite;
                    public static Sprite getSoulSprite()
                    {
                        if (soulSprite) return soulSprite;
                        soulSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Soul.png", 500f);
                        return soulSprite;
                    }

                    public static void clearAndReload()
                    {
                        seer = null;
                        deadBodyPositions = new List<Vector3>();
                        limitSoulDuration = CustomOptionHolder.seerLimitSoulDuration.getBool();
                        soulDuration = CustomOptionHolder.seerSoulDuration.getFloat();
                        mode = CustomOptionHolder.seerMode.getSelection();
                    }
                }

                public static class Morphling
                {
                    public static PlayerControl morphling;
                    public static Color color = Palette.ImpostorRed;
                    private static Sprite sampleSprite;
                    private static Sprite morphSprite;

                    public static float cooldown = 30f;
                    public static float duration = 10f;

                    public static PlayerControl currentTarget;
                    public static PlayerControl sampledTarget;
                    public static PlayerControl morphTarget;
                    public static float morphTimer = 0f;

                    public static void handleMorphing()
                    {
                        if (morphling == null) return;

                        // first, if camo is active, don't do anything
                        if (Camouflager.camouflager != null && Camouflager.camouflageTimer > 0f) return;

                        // next, if we're currently morphed, set our skin to the target
                        if (morphTimer > 0f && morphTarget != null && MorphData.morphData.ContainsKey(morphTarget.PlayerId))
                        {
                            MorphData.morphData[morphTarget.PlayerId]?.applyToPlayer(morphling);
                        }
                        else if (MorphData.morphData.ContainsKey(morphling.PlayerId))
                        {
                            MorphData.morphData[morphling.PlayerId]?.applyToPlayer(morphling);
                        }
                        else
                        {
                            TheOtherRolesPlugin.Instance.Log.LogError("handleMorphing failed?");
                        }
                    }

                    public static void startMorph(PlayerControl target)
                    {
                        morphTarget = target;
                        morphTimer = duration;
                        handleMorphing();
                    }

                    public static void resetMorph()
                    {
                        morphTarget = null;
                        morphTimer = 0f;
                        handleMorphing();
                    }

                    public static void clearAndReload()
                    {
                        resetMorph();
                        morphling = null;
                        currentTarget = null;
                        sampledTarget = null;
                        morphTarget = null;
                        morphTimer = 0f;
                        cooldown = CustomOptionHolder.morphlingCooldown.getFloat();
                        duration = CustomOptionHolder.morphlingDuration.getFloat();
                    }

                    public static Sprite getSampleSprite()
                    {
                        if (sampleSprite) return sampleSprite;
                        sampleSprite = ModTranslation.getImage("SampleButton", 115f);
                        return sampleSprite;
                    }

                    public static Sprite getMorphSprite()
                    {
                        if (morphSprite) return morphSprite;
                        morphSprite = ModTranslation.getImage("MorphButton", 115f);
                        return morphSprite;
                    }
                }

                public static class Camouflager
                {
                    public static PlayerControl camouflager;
                    public static Color color = Palette.ImpostorRed;

                    public static float cooldown = 30f;
                    public static float duration = 10f;
                    public static float camouflageTimer = 0f;
                    public static bool randomColors = false;

                    public static MorphData camoData;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("CamoButton", 115f);
                        return buttonSprite;
                    }

                    public static void startCamouflage()
                    {
                        camouflageTimer = duration;

                        if (randomColors)
                            camoData.color = (byte)TheOtherRoles.rnd.Next(0, Palette.PlayerColors.Length);
                        else
                            camoData.color = 6;

                        foreach (PlayerControl p in PlayerControl.AllPlayerControls)
                        {
                            if (p == null) continue;
                            camoData.applyToPlayer(p);
                        }
                    }

                    public static void resetCamouflage()
                    {
                        camouflageTimer = 0f;
                        foreach (PlayerControl p in PlayerControl.AllPlayerControls)
                        {
                            if (p == null) continue;
                            if (!MorphData.morphData.ContainsKey(p.PlayerId)) continue;

                            // special case for morphling
                            if (Morphling.morphling?.PlayerId == p.PlayerId)
                            {
                                Morphling.handleMorphing();
                            }
                            else
                            {
                                MorphData.morphData[p.PlayerId].applyToPlayer(p);
                            }
                        }
                    }

                    public static void clearAndReload()
                    {
                        resetCamouflage();
                        camouflager = null;
                        camouflageTimer = 0f;
                        cooldown = CustomOptionHolder.camouflagerCooldown.getFloat();
                        duration = CustomOptionHolder.camouflagerDuration.getFloat();
                        randomColors = CustomOptionHolder.camouflagerRandomColors.getBool();

                        camoData = new MorphData();
                        camoData.name = "";
                        camoData.hat = "";
                        camoData.color = 6;
                        camoData.skin = "";
                        camoData.pet = "";
                    }
                }

                public static class Hacker
                {
                    public static PlayerControl hacker;
                    public static Color color = new Color32(117, 250, 76, byte.MaxValue);

                    public static float cooldown = 30f;
                    public static float duration = 10f;
                    public static bool onlyColorType = false;
                    public static float hackerTimer = 0f;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("HackerButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        hacker = null;
                        hackerTimer = 0f;
                        cooldown = CustomOptionHolder.hackerCooldown.getFloat();
                        duration = CustomOptionHolder.hackerHackeringDuration.getFloat();
                        onlyColorType = CustomOptionHolder.hackerOnlyColorType.getBool();
                    }
                }

                public static class Mini
                {
                    public static PlayerControl mini;
                    public static Color color = Color.white;
                    public const float defaultColliderRadius = 0.2233912f;
                    public const float defaultColliderOffset = 0.3636057f;

                    public static float growingUpDuration = 400f;
                    public static DateTime timeOfGrowthStart = DateTime.UtcNow;
                    public static bool triggerMiniLose = false;

                    public static void clearAndReload()
                    {
                        mini = null;
                        triggerMiniLose = false;
                        growingUpDuration = CustomOptionHolder.miniGrowingUpDuration.getFloat();
                        timeOfGrowthStart = DateTime.UtcNow;
                    }

                    public static float growingProgress()
                    {
                        if (timeOfGrowthStart == null) return 0f;

                        float timeSinceStart = (float)(DateTime.UtcNow - timeOfGrowthStart).TotalMilliseconds;
                        return Mathf.Clamp(timeSinceStart / (growingUpDuration * 1000), 0f, 1f);
                    }

                    public static bool isGrownUp()
                    {
                        return growingProgress() == 1f;
                    }
                }

                public static class Tracker
                {
                    public static PlayerControl tracker;
                    public static Color color = new Color32(100, 58, 220, byte.MaxValue);

                    public static float updateIntervall = 5f;
                    public static bool resetTargetAfterMeeting = false;

                    public static PlayerControl currentTarget;
                    public static PlayerControl tracked;
                    public static bool usedTracker = false;
                    public static float timeUntilUpdate = 0f;
                    public static Arrow arrow = new Arrow(Color.blue);

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("TrackerButton", 115f);
                        return buttonSprite;
                    }

                    public static void resetTracked()
                    {
                        currentTarget = tracked = null;
                        usedTracker = false;
                        if (arrow?.arrow != null) UnityEngine.Object.Destroy(arrow.arrow);
                        arrow = new Arrow(Color.blue);
                        if (arrow.arrow != null) arrow.arrow.SetActive(false);
                    }

                    public static void clearAndReload()
                    {
                        tracker = null;
                        resetTracked();
                        timeUntilUpdate = 0f;
                        updateIntervall = CustomOptionHolder.trackerUpdateIntervall.getFloat();
                        resetTargetAfterMeeting = CustomOptionHolder.trackerResetTargetAfterMeeting.getBool();
                    }
                }

                public static class Vampire
                {
                    public static PlayerControl vampire;
                    public static Color color = Palette.ImpostorRed;

                    public static float delay = 10f;
                    public static float cooldown = 30f;
                    public static bool canKillNearGarlics = true;
                    public static bool localPlacedGarlic = false;
                    public static bool garlicsActive = true;

                    public static PlayerControl currentTarget;
                    public static PlayerControl bitten;
                    public static bool targetNearGarlic = false;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("VampireButton", 115f);
                        return buttonSprite;
                    }

                    private static Sprite garlicButtonSprite;
                    public static Sprite getGarlicButtonSprite()
                    {
                        if (garlicButtonSprite) return garlicButtonSprite;
                        garlicButtonSprite = ModTranslation.getImage("GarlicButton", 115f);
                        return garlicButtonSprite;
                    }

                    public static void clearAndReload()
                    {
                        vampire = null;
                        bitten = null;
                        targetNearGarlic = false;
                        localPlacedGarlic = false;
                        currentTarget = null;
                        garlicsActive = CustomOptionHolder.vampireSpawnRate.getSelection() > 0;
                        delay = CustomOptionHolder.vampireKillDelay.getFloat();
                        cooldown = CustomOptionHolder.vampireCooldown.getFloat();
                        canKillNearGarlics = CustomOptionHolder.vampireCanKillNearGarlics.getBool();
                    }
                }

                public static class Snitch
                {
                    public static PlayerControl snitch;
                    public static Color color = new Color32(184, 251, 79, byte.MaxValue);

                    public static List<Arrow> localArrows = new List<Arrow>();
                    public static int taskCountForReveal = 1;
                    public static bool includeTeamJackal = false;
                    public static bool teamJackalUseDifferentArrowColor = true;


                    public static void clearAndReload()
                    {
                        if (localArrows != null)
                        {
                            foreach (Arrow arrow in localArrows)
                                if (arrow?.arrow != null)
                                    UnityEngine.Object.Destroy(arrow.arrow);
                        }
                        localArrows = new List<Arrow>();
                        taskCountForReveal = Mathf.RoundToInt(CustomOptionHolder.snitchLeftTasksForReveal.getFloat());
                        includeTeamJackal = CustomOptionHolder.snitchIncludeTeamJackal.getBool();
                        teamJackalUseDifferentArrowColor = CustomOptionHolder.snitchTeamJackalUseDifferentArrowColor.getBool();
                        snitch = null;
                    }
                }

                public static class Jackal
                {
                    public static PlayerControl jackal;
                    public static Color color = new Color32(0, 180, 235, byte.MaxValue);
                    public static PlayerControl fakeSidekick;
                    public static PlayerControl currentTarget;
                    public static List<PlayerControl> formerJackals = new List<PlayerControl>();

                    public static float cooldown = 30f;
                    public static float createSidekickCooldown = 30f;
                    public static bool canUseVents = true;
                    public static bool canCreateSidekick = true;
                    public static Sprite buttonSprite;
                    public static bool jackalPromotedFromSidekickCanCreateSidekick = true;
                    public static bool canCreateSidekickFromImpostor = true;
                    public static bool hasImpostorVision = false;
                    public static bool canSeeEngineerVent = false;

                    public static Sprite getSidekickButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("SidekickButton", 115f);
                        return buttonSprite;
                    }

                    public static void removeCurrentJackal()
                    {
                        if (!formerJackals.Any(x => x.PlayerId == jackal.PlayerId)) formerJackals.Add(jackal);
                        jackal = null;
                        currentTarget = null;
                        fakeSidekick = null;
                        cooldown = CustomOptionHolder.jackalKillCooldown.getFloat();
                        createSidekickCooldown = CustomOptionHolder.jackalCreateSidekickCooldown.getFloat();
                    }

                    public static void clearAndReload()
                    {
                        jackal = null;
                        currentTarget = null;
                        fakeSidekick = null;
                        cooldown = CustomOptionHolder.jackalKillCooldown.getFloat();
                        createSidekickCooldown = CustomOptionHolder.jackalCreateSidekickCooldown.getFloat();
                        canUseVents = CustomOptionHolder.jackalCanUseVents.getBool();
                        canCreateSidekick = CustomOptionHolder.jackalCanCreateSidekick.getBool();
                        jackalPromotedFromSidekickCanCreateSidekick = CustomOptionHolder.jackalPromotedFromSidekickCanCreateSidekick.getBool();
                        canCreateSidekickFromImpostor = CustomOptionHolder.jackalCanCreateSidekickFromImpostor.getBool();
                        formerJackals.Clear();
                        hasImpostorVision = CustomOptionHolder.jackalAndSidekickHaveImpostorVision.getBool();
                        canSeeEngineerVent = CustomOptionHolder.jackalCanSeeEngineerVent.getBool();
                    }

                }

                public static class Sidekick
                {
                    public static PlayerControl sidekick;
                    public static Color color = new Color32(0, 180, 235, byte.MaxValue);

                    public static PlayerControl currentTarget;

                    public static float cooldown = 30f;
                    public static bool canUseVents = true;
                    public static bool canKill = true;
                    public static bool promotesToJackal = true;
                    public static bool hasImpostorVision = false;

                    public static void clearAndReload()
                    {
                        sidekick = null;
                        currentTarget = null;
                        cooldown = CustomOptionHolder.jackalKillCooldown.getFloat();
                        canUseVents = CustomOptionHolder.sidekickCanUseVents.getBool();
                        canKill = CustomOptionHolder.sidekickCanKill.getBool();
                        promotesToJackal = CustomOptionHolder.sidekickPromotesToJackal.getBool();
                        hasImpostorVision = CustomOptionHolder.jackalAndSidekickHaveImpostorVision.getBool();
                    }
                }

                public static class Eraser
                {
                    public static PlayerControl eraser;
                    public static Color color = Palette.ImpostorRed;

                    public static List<PlayerControl> futureErased = new List<PlayerControl>();
                    public static PlayerControl currentTarget;
                    public static float cooldown = 30f;
                    public static float cooldownIncrease = 10f;
                    public static bool canEraseAnyone = false;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("EraserButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        eraser = null;
                        futureErased = new List<PlayerControl>();
                        currentTarget = null;
                        cooldown = CustomOptionHolder.eraserCooldown.getFloat();
                        cooldownIncrease = CustomOptionHolder.eraserCooldownIncrease.getFloat();
                        canEraseAnyone = CustomOptionHolder.eraserCanEraseAnyone.getBool();
                    }
                }

                public static class Spy
                {
                    public static PlayerControl spy;
                    public static Color color = Palette.ImpostorRed;

                    public static bool impostorsCanKillAnyone = true;
                    public static bool canEnterVents = false;
                    public static bool hasImpostorVision = false;

                    public static void clearAndReload()
                    {
                        spy = null;
                        impostorsCanKillAnyone = CustomOptionHolder.spyImpostorsCanKillAnyone.getBool();
                        canEnterVents = CustomOptionHolder.spyCanEnterVents.getBool();
                        hasImpostorVision = CustomOptionHolder.spyHasImpostorVision.getBool();
                    }
                }

                public static class Trickster
                {
                    public static PlayerControl trickster;
                    public static Color color = Palette.ImpostorRed;
                    public static float placeBoxCooldown = 30f;
                    public static float lightsOutCooldown = 30f;
                    public static float lightsOutDuration = 10f;
                    public static float lightsOutTimer = 0f;

                    private static Sprite placeBoxButtonSprite;
                    private static Sprite lightOutButtonSprite;
                    private static Sprite tricksterVentButtonSprite;

                    private static VentButton tricksterVentButton;

                    public static Sprite getPlaceBoxButtonSprite()
                    {
                        if (placeBoxButtonSprite) return placeBoxButtonSprite;
                        placeBoxButtonSprite = ModTranslation.getImage("PlaceJackInTheBoxButton", 115f);
                        return placeBoxButtonSprite;
                    }

                    public static Sprite getLightsOutButtonSprite()
                    {
                        if (lightOutButtonSprite) return lightOutButtonSprite;
                        lightOutButtonSprite = ModTranslation.getImage("LightsOutButton", 115f);
                        return lightOutButtonSprite;
                    }

                    public static Sprite getTricksterVentButtonSprite()
                    {
                        if (tricksterVentButtonSprite) return tricksterVentButtonSprite;
                        tricksterVentButtonSprite = ModTranslation.getImage("TricksterVentButton", 115f);
                        return tricksterVentButtonSprite;
                    }

                    public static VentButton getTricksterVentButton()
                    {
                        if (tricksterVentButton == null)
                        {
                            VentButton template = DestroyableSingleton<HudManager>.Instance.ImpostorVentButton;
                            tricksterVentButton = UnityEngine.Object.Instantiate(template, DestroyableSingleton<HudManager>.Instance.ImpostorVentButton.transform);
                            tricksterVentButton.graphic.sprite = getTricksterVentButtonSprite();
                        }
                        tricksterVentButton.buttonLabelText.enabled = false;
                        tricksterVentButton.buttonLabelText.text = "";

                        return tricksterVentButton;
                    }

                    public static void clearAndReload()
                    {
                        trickster = null;
                        lightsOutTimer = 0f;
                        placeBoxCooldown = CustomOptionHolder.tricksterPlaceBoxCooldown.getFloat();
                        lightsOutCooldown = CustomOptionHolder.tricksterLightsOutCooldown.getFloat();
                        lightsOutDuration = CustomOptionHolder.tricksterLightsOutDuration.getFloat();
                        JackInTheBox.UpdateStates(); // if the role is erased, we might have to update the state of the created objects
                    }

                }

                public static class Cleaner
                {
                    public static PlayerControl cleaner;
                    public static Color color = Palette.ImpostorRed;

                    public static float cooldown = 30f;

                    private static Sprite buttonSprite;
                    public static Sprite getButtonSprite()
                    {
                        if (buttonSprite) return buttonSprite;
                        buttonSprite = ModTranslation.getImage("CleanButton", 115f);
                        return buttonSprite;
                    }

                    public static void clearAndReload()
                    {
                        cleaner = null;
                        cooldown = CustomOptionHolder.cleanerCooldown.getFloat();
                    }
                }

                public static class Warlock
                {

                    public static PlayerControl warlock;
                    public static Color color = Palette.ImpostorRed;

                    public static PlayerControl currentTarget;
                    public static PlayerControl curseVictim;
                    public static PlayerControl curseVictimTarget;
                    public static PlayerControl curseKillTarget;

                    public static float cooldown = 30f;
                    public static float rootTime = 5f;

                    private static Sprite curseButtonSprite;
                    private static Sprite curseKillButtonSprite;

                    public static Sprite getCurseButtonSprite()
                    {
                        if (curseButtonSprite) return curseButtonSprite;
                        curseButtonSprite = ModTranslation.getImage("CurseButton", 115f);
                        return curseButtonSprite;
                    }

                    public static Sprite getCurseKillButtonSprite()
                    {
                        if (curseKillButtonSprite) return curseKillButtonSprite;
                        curseKillButtonSprite = ModTranslation.getImage("CurseKillButton", 115f);
                        return curseKillButtonSprite;
                    }

                    public static void clearAndReload()
                    {
                        warlock = null;
                        currentTarget = null;
                        curseVictim = null;
                        curseVictimTarget = null;
                        curseKillTarget = null;
                        cooldown = CustomOptionHolder.warlockCooldown.getFloat();
                        rootTime = CustomOptionHolder.warlockRootTime.getFloat();
                    }

                    public static void resetCurse()
                    {
                        HudManagerStartPatch.warlockCurseButton.Timer = HudManagerStartPatch.warlockCurseButton.MaxTimer;
                        HudManagerStartPatch.warlockCurseButton.Sprite = Warlock.getCurseButtonSprite();
                        HudManagerStartPatch.warlockCurseButton.killButton.cooldownTimerText.color = Palette.EnabledColor;
                        currentTarget = null;
                        curseVictim = null;
                        curseVictimTarget = null;
                        curseKillTarget = null;
                    }
                }

                public static class SecurityGuard
                {
                    public static PlayerControl securityGuard;
                    public static Color color = new Color32(195, 178, 95, byte.MaxValue);

                    public static float cooldown = 30f;
                    public static int remainingScrews = 7;
                    public static int totalScrews = 7;
                    public static int ventPrice = 1;
                    public static int camPrice = 2;
                    public static int placedCameras = 0;
                    public static Vent ventTarget = null;

                    private static Sprite closeVentButtonSprite;
                    public static Sprite getCloseVentButtonSprite()
                    {
                        if (closeVentButtonSprite) return closeVentButtonSprite;
                        closeVentButtonSprite = ModTranslation.getImage("CloseVentButton", 115f);
                        return closeVentButtonSprite;
                    }

                    private static Sprite placeCameraButtonSprite;
                    public static Sprite getPlaceCameraButtonSprite()
                    {
                        if (placeCameraButtonSprite) return placeCameraButtonSprite;
                        placeCameraButtonSprite = ModTranslation.getImage("PlaceCameraButton", 115f);
                        return placeCameraButtonSprite;
                    }

                    private static Sprite animatedVentSealedSprite;
                    public static Sprite getAnimatedVentSealedSprite()
                    {
                        if (animatedVentSealedSprite) return animatedVentSealedSprite;
                        animatedVentSealedSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.AnimatedVentSealed.png", 160f);
                        return animatedVentSealedSprite;
                    }

                    private static Sprite staticVentSealedSprite;
                    public static Sprite getStaticVentSealedSprite()
                    {
                        if (staticVentSealedSprite) return staticVentSealedSprite;
                        staticVentSealedSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.StaticVentSealed.png", 160f);
                        return staticVentSealedSprite;
                    }

                    public static void clearAndReload()
                    {
                        securityGuard = null;
                        ventTarget = null;
                        placedCameras = 0;
                        cooldown = CustomOptionHolder.securityGuardCooldown.getFloat();
                        totalScrews = remainingScrews = Mathf.RoundToInt(CustomOptionHolder.securityGuardTotalScrews.getFloat());
                        camPrice = Mathf.RoundToInt(CustomOptionHolder.securityGuardCamPrice.getFloat());
                        ventPrice = Mathf.RoundToInt(CustomOptionHolder.securityGuardVentPrice.getFloat());
                    }
                }

                public static class Arsonist
                {
                    public static PlayerControl arsonist;
                    public static Color color = new Color32(238, 112, 46, byte.MaxValue);

                    public static float cooldown = 30f;
                    public static float duration = 3f;
                    public static bool triggerArsonistWin = false;
                    public static bool dousedEveryone = false;

                    public static PlayerControl currentTarget;
                    public static PlayerControl douseTarget;
                    public static List<PlayerControl> dousedPlayers = new List<PlayerControl>();

                    private static Sprite douseSprite;
                    public static Sprite getDouseSprite()
                    {
                        if (douseSprite) return douseSprite;
                        douseSprite = ModTranslation.getImage("DouseButton", 115f);
                        return douseSprite;
                    }

                    private static Sprite igniteSprite;
                    public static Sprite getIgniteSprite()
                    {
                        if (igniteSprite) return igniteSprite;
                        igniteSprite = ModTranslation.getImage("IgniteButton", 115f);
                        return igniteSprite;
                    }

                    public static bool dousedEveryoneAlive()
                    {
                        return PlayerControl.AllPlayerControls.ToArray().All(x => { return x.isRole(CustomRoleTypes.Arsonist) || x.Data.IsDead || x.Data.Disconnected || x.isRole(CustomRoleTypes.GM) || Arsonist.dousedPlayers.Any(y => y.PlayerId == x.PlayerId); });
                    }

                    public static void updateStatus()
                    {
                        if (Arsonist.arsonist != null && Arsonist.arsonist == PlayerControl.LocalPlayer) { 
                            dousedEveryone = dousedEveryoneAlive();
                        }
                    }

                    public static void updateIcons()
                    {
                        if (Arsonist.arsonist != null && Arsonist.arsonist == PlayerControl.LocalPlayer)
                        {
                            int visibleCounter = 0;
                            Vector3 bottomLeft = DestroyableSingleton<HudManager>.Instance.UseButton.transform.localPosition;
                            bottomLeft.x *= -1;
                            bottomLeft += new Vector3(-0.25f, -0.25f, 0);

                            foreach (PlayerControl p in PlayerControl.AllPlayerControls)
                            {
                                if (p.PlayerId == PlayerControl.LocalPlayer.PlayerId) continue;
                                if (!MapOptions.playerIcons.ContainsKey(p.PlayerId)) continue;

                                if (p.Data.IsDead || p.Data.Disconnected)
                                {
                                    MapOptions.playerIcons[p.PlayerId].gameObject.SetActive(false);
                                }
                                else
                                {
                                    MapOptions.playerIcons[p.PlayerId].gameObject.SetActive(true);
                                    MapOptions.playerIcons[p.PlayerId].transform.localScale = Vector3.one * 0.25f;
                                    MapOptions.playerIcons[p.PlayerId].transform.localPosition = bottomLeft + Vector3.right * visibleCounter * 0.45f;
                                    visibleCounter++;
                                }
                                bool isDoused = dousedPlayers.Any(x => x.PlayerId == p.PlayerId);
                                MapOptions.playerIcons[p.PlayerId].setSemiTransparent(!isDoused);
                            }
                        }
                    }

                    public static void clearAndReload()
                    {
                        arsonist = null;
                        currentTarget = null;
                        douseTarget = null;
                        triggerArsonistWin = false;
                        dousedEveryone = false;
                        dousedPlayers = new List<PlayerControl>();
                        foreach (PoolablePlayer p in MapOptions.playerIcons.Values)
                        {
                            if (p != null && p.gameObject != null) p.gameObject.SetActive(false);
                        }
                        cooldown = CustomOptionHolder.arsonistCooldown.getFloat();
                        duration = CustomOptionHolder.arsonistDuration.getFloat();
                    }
                }

                public static class Guesser
                {
                    public static PlayerControl guesser;
                    public static Color color = new Color32(255, 255, 0, byte.MaxValue);
                    private static Sprite targetSprite;

                    public static int remainingShots = 2;
                    public static bool onlyAvailableRoles = true;
                    public static bool hasMultipleShotsPerMeeting = false;

                    public static Sprite getTargetSprite()
                    {
                        if (targetSprite) return targetSprite;
                        targetSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.TargetIcon.png", 150f);
                        return targetSprite;
                    }

                    public static void clearAndReload()
                    {
                        guesser = null;

                        remainingShots = Mathf.RoundToInt(CustomOptionHolder.guesserNumberOfShots.getFloat());
                        onlyAvailableRoles = CustomOptionHolder.guesserOnlyAvailableRoles.getBool();
                        hasMultipleShotsPerMeeting = CustomOptionHolder.guesserHasMultipleShotsPerMeeting.getBool();
                    }
                }

                public static class BountyHunter
                {
                    public static PlayerControl bountyHunter;
                    public static Color color = Palette.ImpostorRed;

                    public static Arrow arrow;
                    public static float bountyDuration = 30f;
                    public static bool showArrow = true;
                    public static float bountyKillCooldown = 0f;
                    public static float punishmentTime = 15f;
                    public static float arrowUpdateIntervall = 10f;

                    public static float arrowUpdateTimer = 0f;
                    public static float bountyUpdateTimer = 0f;
                    public static PlayerControl bounty;
                    public static TMPro.TextMeshPro cooldownText;

                    public static void clearAndReload()
                    {
                        arrow = new Arrow(color);
                        bountyHunter = null;
                        bounty = null;
                        arrowUpdateTimer = 0f;
                        bountyUpdateTimer = 0f;
                        if (arrow != null && arrow.arrow != null) UnityEngine.Object.Destroy(arrow.arrow);
                        arrow = null;
                        if (cooldownText != null && cooldownText.gameObject != null) UnityEngine.Object.Destroy(cooldownText.gameObject);
                        cooldownText = null;
                        foreach (PoolablePlayer p in MapOptions.playerIcons.Values)
                        {
                            if (p != null && p.gameObject != null) p.gameObject.SetActive(false);
                        }


                        bountyDuration = CustomOptionHolder.bountyHunterBountyDuration.getFloat();
                        bountyKillCooldown = CustomOptionHolder.bountyHunterReducedCooldown.getFloat();
                        punishmentTime = CustomOptionHolder.bountyHunterPunishmentTime.getFloat();
                        showArrow = CustomOptionHolder.bountyHunterShowArrow.getBool();
                        arrowUpdateIntervall = CustomOptionHolder.bountyHunterArrowUpdateIntervall.getFloat();
                    }
                }

                public static class GM
                {
                    public static PlayerControl gm;
                    public static Color color = new Color32(255, 91, 112, byte.MaxValue);

                    public static bool gmIsHost = true;
                    public static bool diesAtStart = true;
                    public static bool hasTasks = false;
                    public static bool canSabotage = false;
                    public static bool canWarp = true;
                    public static bool canKill = false;

                    public static UseButton blockedButton;

                    private static Sprite zoomInSprite;
                    private static Sprite zoomOutSprite;

                    public static Sprite getZoomInSprite()
                    {
                        if (zoomInSprite) return zoomInSprite;
                        zoomInSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.GMZoomIn.png", 115f / 2f);
                        return zoomInSprite;
                    }
                    public static Sprite getZoomOutSprite()
                    {
                        if (zoomOutSprite) return zoomOutSprite;
                        zoomOutSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.GMZoomOut.png", 115f / 2f);
                        return zoomOutSprite;
                    }

                    public static UseButton getBlockedButton()
                    {
                        if (blockedButton == null)
                        {
                            UseButton template = DestroyableSingleton<HudManager>.Instance.UseButton;
                            blockedButton = UnityEngine.Object.Instantiate(template, DestroyableSingleton<HudManager>.Instance.UseButton.transform);
                        }

                        blockedButton.buttonLabelText.text = ModTranslation.getString("buttonBlocked");
                        return blockedButton;
                    }

                    public static void resetZoom()
                    {
                        Camera.main.orthographicSize = 3.0f;
                        DestroyableSingleton<HudManager>.Instance.UICamera.orthographicSize = 3.0f;
                        DestroyableSingleton<HudManager>.Instance.transform.localScale = Vector3.one;
                    }

                    public static void clearAndReload()
                    {
                        gm = null;
                        gmIsHost = CustomOptionHolder.gmIsHost.getBool();
                        diesAtStart = CustomOptionHolder.gmDiesAtStart.getBool();
                        hasTasks = false;
                        canSabotage = false;
                        blockedButton = null;
                        zoomInSprite = null;
                        zoomOutSprite = null;
                        canWarp = CustomOptionHolder.gmCanWarp.getBool();
                        canKill = CustomOptionHolder.gmCanKill.getBool();

                        foreach (PoolablePlayer p in MapOptions.playerIcons.Values)
                        {
                            if (p != null && p.gameObject != null) p.gameObject.SetActive(false);
                        }
                    }
                }
                public static class Opportunist
                {
                    public static PlayerControl opportunist;
                    public static Color color = new Color32(0, 255, 00, byte.MaxValue);

                    public static void clearAndReload()
                    {
                        opportunist = null;
                    }
                }
            }

            public static class Vulture {
                public static PlayerControl vulture;
                public static Color color = new Color32(139, 69, 19, byte.MaxValue);
                public static List<Arrow> localArrows = new List<Arrow>();
                public static float cooldown = 30f;
                public static int vultureNumberToWin = 4;
                public static int eatenBodies = 0;
                public static bool triggerVultureWin = false;
                public static bool canUseVents = true;
                public static bool showArrows = true;
                private static Sprite buttonSprite;
                public static Sprite getButtonSprite() {
                    if (buttonSprite) return buttonSprite;
                    buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.VultureButton.png", 115f);
                    return buttonSprite;
                }

                public static void clearAndReload() {
                    vulture = null;
                    vultureNumberToWin = Mathf.RoundToInt(CustomOptionHolder.vultureNumberToWin.getFloat());
                    eatenBodies = 0;
                    cooldown = CustomOptionHolder.vultureCooldown.getFloat();
                    triggerVultureWin = false;
                    canUseVents = CustomOptionHolder.vultureCanUseVents.getBool();
                    showArrows = CustomOptionHolder.vultureShowArrows.getBool();
                    if (localArrows != null) {
                        foreach (Arrow arrow in localArrows)
                            if (arrow?.arrow != null)
                                UnityEngine.Object.Destroy(arrow.arrow);
                    }
                    localArrows = new List<Arrow>();
                }
            }


            public static class Medium {
                public static PlayerControl medium;
                public static DeadPlayer target;
                public static DeadPlayer soulTarget;
                public static Color color = new Color32(98, 120, 115, byte.MaxValue);
                public static List<Tuple<DeadPlayer, Vector3>> deadBodies = new List<Tuple<DeadPlayer, Vector3>>();
                public static List<Tuple<DeadPlayer, Vector3>> featureDeadBodies = new List<Tuple<DeadPlayer, Vector3>>();
                public static List<SpriteRenderer> souls = new List<SpriteRenderer>();
                public static DateTime meetingStartTime = DateTime.UtcNow;

                public static float cooldown = 30f;
                public static float duration = 3f;
                public static bool oneTimeUse = false;

                private static Sprite soulSprite;
                public static Sprite getSoulSprite() {
                    if (soulSprite) return soulSprite;
                    soulSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Soul.png", 500f);
                    return soulSprite;
                }

                private static Sprite question;
                public static Sprite getQuestionSprite() {
                    if (question) return question;
                    question = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.MediumButton.png", 115f);
                    return question;
                }

                public static void clearAndReload() {
                    medium = null;
                    target = null;
                    soulTarget = null;
                    deadBodies = new List<Tuple<DeadPlayer, Vector3>>();
                    featureDeadBodies = new List<Tuple<DeadPlayer, Vector3>>();
                    souls = new List<SpriteRenderer>();
                    meetingStartTime = DateTime.UtcNow;
                    cooldown = CustomOptionHolder.mediumCooldown.getFloat();
                    duration = CustomOptionHolder.mediumDuration.getFloat();
                    oneTimeUse = CustomOptionHolder.mediumOneTimeUse.getBool();
                }
            }


            public static class Sheriff
            {
                public static PlayerControl sheriff;
                public static Color color = new Color32(248, 205, 70, byte.MaxValue);

                public static float cooldown = 30f;
                public static int numShots = 2;
                public static int maxShots = 2;
                public static bool canKillNeutrals = false;
                public static bool misfireKillsTarget = false;
                public static bool spyCanDieToSheriff = false;
                public static bool madmateCanDieToSheriff = false;

                public static PlayerControl currentTarget;

                public static void clearAndReload()
                {
                    sheriff = null;
                    currentTarget = null;
                    cooldown = CustomOptionHolder.sheriffCooldown.getFloat();
                    maxShots = numShots = (int)CustomOptionHolder.sheriffNumShots.getFloat();
                    canKillNeutrals = CustomOptionHolder.sheriffCanKillNeutrals.getBool();
                    spyCanDieToSheriff = CustomOptionHolder.spyCanDieToSheriff.getBool();
                    madmateCanDieToSheriff = CustomOptionHolder.madmateCanDieToSheriff.getBool();
                    misfireKillsTarget = CustomOptionHolder.sheriffMisfireKillsTarget.getBool();
                }
            }*/
    }
}