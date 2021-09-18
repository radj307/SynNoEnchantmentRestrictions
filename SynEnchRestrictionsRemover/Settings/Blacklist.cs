using System.Collections.Generic;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace SynEnchRestrictionsRemover
{
    public class Blacklist
    {
        [SettingName("Armor Blacklist")]
        public List<FormLink<IArmorGetter>> BlacklistArmors = new()
        {

        };
        [SettingName("Weapon Blacklist")]
        public List<FormLink<IWeaponGetter>> BlacklistWeapons = new()
        {

        };
        [SettingName("Mod Blacklist")]
        public List<ModKey> BlacklistMods = new()
        {

        };

        public bool IsBlacklisted(ModKey mod)
        {
            return BlacklistMods.Contains(mod);
        }
        public bool IsBlacklisted(IArmorGetter armor)
        {
            return IsBlacklisted(armor.FormKey.ModKey) || BlacklistArmors.Contains(armor.FormKey);
        }
        public bool IsBlacklisted(IWeaponGetter weapon)
        {
            return IsBlacklisted(weapon.FormKey.ModKey) || BlacklistWeapons.Contains(weapon.FormKey);
        }
    }
}
