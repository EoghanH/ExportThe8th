using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * Getting a bit sleepy, and we're late in the project - so this is gunna be lazy code.
 */
public class StatCounter : MonoBehaviour {

    int month = 1;
    int year = 1991;

    int total_all = 0;
    int total_u19 = 0;
    int total_20_24 = 0;
    int total_25_29 = 0;
    int total_30_34 = 0;
    int total_35_39 = 0;
    int total_40u = 0;

    int ytd_all = 0;
    int ytd_u19 = 0;
    int ytd_20_24 = 0;
    int ytd_25_29 = 0;
    int ytd_30_34 = 0;
    int ytd_35_39 = 0;
    int ytd_40u = 0;

    public GameObject headerTextGO;
    public GameObject monthTextGO;
    public GameObject womenExportedYYYYGO;
    public GameObject breakdownYYYYGO;

    public GameObject totalAllValueGO;
    public GameObject yearAllValueGO;

    public GameObject totalU19GO;
    public GameObject total20_24GO;
    public GameObject total25_29GO;
    public GameObject total30_34GO;
    public GameObject total35_39GO;
    public GameObject total40UGO;

    public GameObject ytdU19GO;
    public GameObject ytd20_24GO;
    public GameObject ytd25_29GO;
    public GameObject ytd30_34GO;
    public GameObject ytd35_39GO;
    public GameObject ytd40UGO;

    TextMeshProUGUI headerText;
    TextMeshProUGUI monthText;
    TextMeshProUGUI womenExportedYYYY;
    TextMeshProUGUI breakdownYYYY;

    TextMeshProUGUI totalAllValue;
    TextMeshProUGUI yearAllValue;

    TextMeshProUGUI totalU19value;
    TextMeshProUGUI total20_24value;
    TextMeshProUGUI total25_29value;
    TextMeshProUGUI total30_34value;
    TextMeshProUGUI total35_39value;
    TextMeshProUGUI total40Uvalue;

    TextMeshProUGUI ytdU19value;
    TextMeshProUGUI ytd20_24value;
    TextMeshProUGUI ytd25_29value;
    TextMeshProUGUI ytd30_34value;
    TextMeshProUGUI ytd35_39value;
    TextMeshProUGUI ytd40Uvalue;

    string[] months = { "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December" };

    private void Start()
    {
        headerText = headerTextGO.GetComponent<TextMeshProUGUI>();
        monthText = monthTextGO.GetComponent<TextMeshProUGUI>();
        womenExportedYYYY = womenExportedYYYYGO.GetComponent<TextMeshProUGUI>();
        breakdownYYYY = breakdownYYYYGO.GetComponent<TextMeshProUGUI>();
        totalAllValue = totalAllValueGO.GetComponent<TextMeshProUGUI>();
        yearAllValue = yearAllValueGO.GetComponent<TextMeshProUGUI>();
        totalU19value = totalU19GO.GetComponent<TextMeshProUGUI>();
        total20_24value = total20_24GO.GetComponent<TextMeshProUGUI>();
        total25_29value = total25_29GO.GetComponent<TextMeshProUGUI>();
        total30_34value = total30_34GO.GetComponent<TextMeshProUGUI>();
        total35_39value = total35_39GO.GetComponent<TextMeshProUGUI>();
        total40Uvalue = total40UGO.GetComponent<TextMeshProUGUI>();
        ytdU19value = ytdU19GO.GetComponent<TextMeshProUGUI>();
        ytd20_24value = ytd20_24GO.GetComponent<TextMeshProUGUI>();
        ytd25_29value = ytd25_29GO.GetComponent<TextMeshProUGUI>();
        ytd30_34value = ytd30_34GO.GetComponent<TextMeshProUGUI>();
        ytd35_39value = ytd35_39GO.GetComponent<TextMeshProUGUI>();
        ytd40Uvalue = ytd40UGO.GetComponent<TextMeshProUGUI>();
    }

    private void updateTextObjects()
    {
        headerText.text = year.ToString();
        monthText.text = months[this.month];
        womenExportedYYYY.text = generateWomenExportedString(year);
        breakdownYYYY.text = generatedBreakdownString(year);

        totalAllValue.text = total_all.ToString();
        yearAllValue.text = ytd_all.ToString();
        totalU19value.text = total_u19.ToString();
        total20_24value.text = total_20_24.ToString();
        total25_29value.text = total_25_29.ToString();
        total30_34value.text = total_30_34.ToString();
        total35_39value.text = total_35_39.ToString();
        total40Uvalue.text = total_40u.ToString();
        ytdU19value.text = ytd_u19.ToString();
        ytd20_24value.text = ytd_20_24.ToString();
        ytd25_29value.text = ytd_25_29.ToString();
        ytd30_34value.text = ytd_30_34.ToString();
        ytd35_39value.text = ytd_35_39.ToString();
        ytd40Uvalue.text = ytd_40u.ToString();
    }

    private string generateWomenExportedString(int year)
    {
        return "Women Exported (" + year.ToString() + "):";
    }

    private string generatedBreakdownString(int year)
    {
        return "Breakdown (" + year.ToString() + ")";
    }

    public void doTick(int tickCount, int ticksPerYear)
    {
        int ticksPerMonth = ticksPerYear / 12;
        this.month = tickCount / ticksPerMonth;
        updateTextObjects();
    }

    public void addAgent(int ageRange)
    {
        total_all++;
        ytd_all++;
        switch (ageRange)
        {
            case 0: total_u19++; ytd_u19++; break;
            case 1: total_20_24++; ytd_20_24++; break;
            case 2: total_25_29++; ytd_25_29++; break;
            case 3: total_30_34++; ytd_30_34++; break;
            case 4: total_35_39++; ytd_35_39++; break;
            case 5: total_40u++; ytd_40u++; break;
        }
    }

    public void setupYear(int year)
    {
        this.year = year;
        ytd_all = 0;
        ytd_u19 = 0;
        ytd_20_24 = 0;
        ytd_25_29 = 0;
        ytd_30_34 = 0;
        ytd_35_39 = 0;
        ytd_40u = 0;
    }
}
