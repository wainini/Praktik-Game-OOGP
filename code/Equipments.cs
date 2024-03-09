class Equipments{
    public Entity entity;

    public Equipables MainHand;
    public Equipables OffHand;
    public Equipables Helm;
    public Equipables Armor;
    public Equipables Boots;
    public Equipables Ring;
    public Equipables Necklace;


    public void Equip(Equipables equip)
    {
        Equipables slot = GetSlot(equip.EquipType);

        if (slot is not null){
            RemoveAlreadyEqupped(slot);
        }

        slot = equip;
    }

    public void RemoveAlreadyEqupped(Equipables slot){
        slot.UnEquip(entity);
    }

    public void UnEquip(Equipables equip)
    {
        Equipables slot = GetSlot(equip.EquipType);
        slot = null;
    }

    public Equipables GetSlot(EquipType type){
        switch(type){
            case EquipType.MainHand:
                return MainHand;
            case EquipType.OffHand:
                return OffHand;
            case EquipType.Helm:
                return Helm;
            case EquipType.Armor:
                return Armor;
            case EquipType.Boots:
                return Boots;
            case EquipType.Ring:
                return Ring;
            case EquipType.Necklace:
                return Necklace;       
        }
        return null;
    }
}