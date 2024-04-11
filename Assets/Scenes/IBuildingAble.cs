using System;
using System.Collections;



public interface ISelectAble
{
    public bool IsSelected { get; set; }
    public int SelectPriority { get; }
    public int DepthPriority { get; }


}

public interface IBuildingAble
{
    public BuildingInfo BuildingStatus { get; set; }

}
