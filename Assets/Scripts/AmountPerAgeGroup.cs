using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountPerAgeGroup {

    public int year;
    public float amount_u19;
    public float amount_20_24;
    public float amount_25_29;
    public float amount_30_34;
    public float amount_35_39;
    public float amount_40u;

	public AmountPerAgeGroup(int year, float amount_u19, float amount_20_24, float amount_25_29, float amount_30_34, float amount_35_39, float amount_40u)
    {
        this.year = year;
        this.amount_u19 = amount_u19;
        this.amount_20_24 = amount_20_24;
        this.amount_25_29 = amount_25_29;
        this.amount_30_34 = amount_30_34;
        this.amount_35_39 = amount_35_39;
        this.amount_40u = amount_40u;
    }
}
