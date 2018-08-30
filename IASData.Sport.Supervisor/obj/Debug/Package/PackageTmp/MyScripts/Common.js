var APIServicePath = "http://localhost:8020/Services/Api/";


function setKeyToNatural() { //EXAMPLES: 0123456789
    if ((window.event.keyCode < 48 || window.event.keyCode > 57) && window.event.keyCode !== 13) {
        event.preventDefault();
        //        event.isDefaultPrevented();
        //        return false;
        //       event.preventDefault();
    }
}

function setKeyToInt() { // EXAMPLES: -350 or 250
    try {
        if ((window.event.keyCode < 48 || window.event.keyCode > 57) && window.event.keyCode !== 45 && window.event.keyCode !== 13)
            event.preventDefault();
    } catch (e) {

    }
}

function setKeyToFloat() { //EXAMPLES: -10.1234 or 11.12 or 32 or -4
    if ((window.event.keyCode < 48 || window.event.keyCode > 57) && window.event.keyCode != 45 && window.event.keyCode != 46 && window.event.keyCode != 13)
        event.preventDefault();
}

function setKeyToDecimal() { //EXAMPLES: 123,456,789
    if ((window.event.keyCode < 48 || window.event.keyCode > 57) && window.event.keyCode != 46 && window.event.keyCode != 13 && window.event.keyCode != 44 && window.event.keyCode != 45)
        event.preventDefault();
}


function setKeyToDate() { //EXAMPLES: 1454/12/12
    if ((window.event.keyCode < 48 || window.event.keyCode > 57) && window.event.keyCode != 47 && window.event.keyCode != 13)
        event.preventDefault();
}
function setKeyToTime() { //EXAMPLES: 1393/12/29 23:59:10
    if ((window.event.keyCode < 48 || window.event.keyCode > 57) && window.event.keyCode != 32 && window.event.keyCode != 47 && window.event.keyCode != 58 && window.event.keyCode != 13)
        event.preventDefault();
}


function setKeyToTab() {
    if (window.event && window.event.keyCode == 13) { window.event.keyCode = 9; }
}

function Separate(CntrlTxt, Price) {
    if (window.event.keyCode != 9 && window.event.keyCode != 16) {
        if (Price.toString().indexOf(".") != -1) {
            splt = Price.toString().split(".");
            CntrlTxt.value = SeparateStr(splt[0].toString()) + "." + splt[1].toString();
        }
        else
            CntrlTxt.value = SeparateStr(Price);
    }
    //CntrlTxt.focus();
    //    var Sel = CntrlTxt.createRange();
    //    CntrlTxt.moveStart('character', -CntrlTxt.value.length);
    //    CntrlTxt.moveEnd('character', 0);


}
function Separate2(id, Price) {
    if (window.event.keyCode != 9 && window.event.keyCode != 16) {
        if (Price.toString().indexOf(".") != -1) {
            splt = Price.toString().split(".");


            document.getElementById(id).value = SeparateStr(splt[0].toString()) + "." + splt[1].toString();
        }
        else
            document.getElementById(id).value = SeparateStr(Price);
    }
    //CntrlTxt.focus();
    //    var Sel = CntrlTxt.createRange();
    //    CntrlTxt.moveStart('character', -CntrlTxt.value.length);
    //    CntrlTxt.moveEnd('character', 0);


}

function SeparateStr(Price) {
    var Separator = ",";
    while (Price.toString().indexOf(",") != -1)
        Price = Price.toString().replace(",", "");
    if (Price.toString().length > 3) {
        var Prc = Price.toString();
        var PrcS = Price.toString();
        var ArrStr = new Array();
        var i;
        var j = parseInt(Prc.length / 3);

        for (i = 0; i < j; i++) {
            ArrStr[i] = Prc.substring(Prc.length - 3);
            Prc = Prc.substring(0, Prc.length - 3);
        }

        //str = new String();
        //str.split

        Prc = "";

        for (i = ArrStr.length - 1; i >= 0; i--)
            if (ArrStr[i] != "")
                Prc = Prc + Separator + ArrStr[i];

        if (PrcS.length % 3 == 0)
            Prc = Prc.substring(1);

        PrcS = PrcS.substring(0, PrcS.length % 3) + Prc;

        return PrcS;
        //CntrlTxt.value = PrcS;
    }
    else
        return Price;
    //CntrlTxt.value = Price;
}

function selectNationality(nID, targetControl, selectedValue) {
    debugger;
    $.getJSON("../Loockup/LoadEthnicsByNationalityId", { id: nID },
        function (data) {
            targetControl.empty();
            targetControl.append($('<option/>', {
                value: 0,
                text: ""
            }));

            $.each(data, function (index, itemData) {
                if (selectedValue != itemData.Value) {
                    targetControl.append($('<option></option>', {
                        value: itemData.Value,
                        text: itemData.Text
                    }));
                }
                else {
                    targetControl.append($('<option selected="selected" value="' + itemData.Value + '">' + itemData.Text + '</option>', {
                        value: itemData.Value,
                        text: itemData.Text,
                    }));
                }
            });
        });
}


function selectProvince(pID, targetControl, selectedValue) {
    debugger;
    $.getJSON("../Loockup/LoadCitiesByProvinceId", { id: pID },
        function (data) {
            targetControl.empty();
            targetControl.append($('<option/>', {
                value: 0,
                text: ""
            }));

            $.each(data, function (index, itemData) {
                if (selectedValue != itemData.Value) {
                    targetControl.append($('<option></option>', {
                        value: itemData.Value,
                        text: itemData.Text
                    }));
                }
                else {
                    targetControl.append($('<option selected="selected" value="' + itemData.Value + '">' + itemData.Text + '</option>', {
                        value: itemData.Value,
                        text: itemData.Text,
                    }));
                }
            });
        });
}


function selectCity(cID, targetControl, selectedValue) {
    debugger;
    $.getJSON("../Loockup/LoadRegionsByCityId", { id: cID },
        function (data) {
            targetControl.empty();
            targetControl.append($('<option/>', {
                value: 0,
                text: ""
            }));

            $.each(data, function (index, itemData) {
                if (selectedValue != itemData.Value) {
                    targetControl.append($('<option></option>', {
                        value: itemData.Value,
                        text: itemData.Text
                    }));
                }
                else {
                    targetControl.append($('<option selected="selected" value="' + itemData.Value + '">' + itemData.Text + '</option>', {
                        value: itemData.Value,
                        text: itemData.Text,
                    }));
                }
            });
        });
}


function selectRegion(rID, targetControl, selectedValue) {
    debugger;
    $.getJSON("../Loockup/LoadSegmentsByRegionId", { id: rID },
        function (data) {
            targetControl.empty();
            targetControl.append($('<option/>', {
                value: 0,
                text: ""
            }));

            $.each(data, function (index, itemData) {
                if (selectedValue != itemData.Value) {
                    targetControl.append($('<option></option>', {
                        value: itemData.Value,
                        text: itemData.Text
                    }));
                }
                else {
                    targetControl.append($('<option selected="selected" value="' + itemData.Value + '">' + itemData.Text + '</option>', {
                        value: itemData.Value,
                        text: itemData.Text,
                    }));
                }
            });
        });
}

function selectJobStatus(jsID, targetControl, selectedValue) {
    debugger;
    $.getJSON("../Loockup/LoadJobsByJobStatusId", { id: jsID },
        function (data) {
            targetControl.empty();
            targetControl.append($('<option/>', {
                value: 0,
                text: ""
            }));

            $.each(data, function (index, itemData) {
                if (selectedValue != itemData.Value) {
                    targetControl.append($('<option></option>', {
                        value: itemData.Value,
                        text: itemData.Text
                    }));
                }
                else {
                    targetControl.append($('<option selected="selected" value="' + itemData.Value + '">' + itemData.Text + '</option>', {
                        value: itemData.Value,
                        text: itemData.Text,
                    }));
                }
            });
        });
}
