$(function () {



    var dataGrid =   $("#gridContainer").dxDataGrid({
        dataSource: weekData,
        allowColumnReordering: false,
        allowColumnResizing: true,
        columnAutoWidth: true,
        grouping: {
            autoExpandAll: true,
        },
        filterRow: {
            visible: true,
            applyFilter: "auto"
        },
        searchPanel: {
            visible: true,
            width: 240,
            placeholder: "Buscar..."
        },
        headerFilter: {
            visible: true
        },
        loadPanel: {
            enabled: true
        },
        scrolling: {
           // mode: "infinite"
            mode: "virtual"
        },
        paging: {
            pageSize: 10
        },
        groupPanel: {
            visible: true,
            placeholder: "Arrastre hasta aqui para agupar"
        },
        export: {
            enabled: true,
            fileName: "weekData"
        },
        editing: {
            mode: "batch",
            allowUpdating: true
        }, 
        columns: [{
            dataField: "Color",
            allowEditing: false, width: 130
            
        },
            { dataField: "Descripcion", allowEditing: false, width: 240  },
            { dataField: "Cubierta 2.40", dataType: "number", width: 120   }, 
            { dataField: "Cubierta 3.00", dataType: "number", width: 120 },
            { dataField: "Cubierta 3.60", dataType: "number", width: 120 } ,
            { dataField: "Barra 2.40", dataType: "number", width: 120 }  ,
            { dataField: "Barra 3.00", dataType: "number", width: 120 } ,
            { dataField: "Barra 3.60", dataType: "number", width: 120}  ,
            { dataField: "Barra 90 2.40", dataType: "number", width: 120} 
        ], summary: {
            totalItems: [{
                column: "Cubierta 2.40",
                summaryType: "sum"
            }, {
                    column: "Cubierta 3.00",
                summaryType: "sum"       
                }, {
                    column: "Cubierta 3.60",
                    summaryType: "sum"
            }, {
                    column: "Barra 2.40",
                summaryType: "sum"
                }, {
                    column: "Barra 3.00",
                    summaryType: "sum"
            }, {
                    column: "Barra 3.60",
                summaryType: "sum"
            }, {
                    column: "Barra 90 2.40",
                summaryType: "sum"
            }]
        },
        onEditingStart: function (e) {
            console.log("EditingStart");
            console.log(e);
            dataGrid.saveEditData();
        },
        
        cellHoverChanged: function (e) {
            console.log("InitNewRow");
            console.log(e);
        },
        onRowInserting: function (e) {
            console.log("RowInserting");
            console.log(e);
        },
        onRowInserted: function (e) {
            console.log("RowInserted");
            console.log(e);
        },
        onRowUpdating: function (e) {
            console.log("RowUpdating");
            console.log(e);
        },
        editingStart: function (e) {
            console.log("RowUpdated");
            console.log(e);
       

        },
        onRowRemoving: function (e) {
            console.log("RowRemoving");
            console.log(e);
        },
        onRowRemoved: function (e) {
            console.log("RowRemoved");
            console.log(e);
        },
        

    }).dxDataGrid("instance");

    $("#autoExpand").dxCheckBox({
        value: true,
        text: "Expand All Groups",
        onValueChanged: function (data) {
            dataGrid.option("grouping.autoExpandAll", data.value);
        }
    });

   


    });






var products = [{
    ID: "1",
    name: "Stores",
    expanded: true
}, { 
    ID: "1_1",
    categoryId: "1",
    name: "Super Mart of the West",
    expanded: true
}, {
    ID: "1_1_1",
    categoryId: "1_1",
    name: "Video Players"
}, {
    ID: "1_1_1_1",
    categoryId: "1_1_1",
    name: "HD Video Player",
    iconSrc: "images/products/1.png",
    price: 220
}, {
    ID: "1_1_1_2",
    categoryId: "1_1_1",
    name: "SuperHD Video Player",
    iconSrc: "images/products/2.png",
    price: 270
}, {
    ID: "1_1_2",
    categoryId: "1_1",
    name: "Televisions",
    expanded: true
}, {
    ID: "1_1_2_1",
    categoryId: "1_1_2",
    name: "SuperLCD 42",
    iconSrc: "images/products/7.png",
    price: 1200
}, {
    ID: "1_1_2_2",
    categoryId: "1_1_2",
    name: "SuperLED 42",
    iconSrc: "images/products/5.png",
    price: 1450
}, {
    ID: "1_1_2_3",
    categoryId: "1_1_2",
    name: "SuperLED 50",
    iconSrc: "images/products/4.png",
    price: 1600
}, {
    ID: "1_1_2_4",
    categoryId: "1_1_2",
    name: "SuperLCD 55",
    iconSrc: "images/products/6.png",
    price: 1750
}, {
    ID: "1_1_2_5",
    categoryId: "1_1_2",
    name: "SuperLCD 70",
    iconSrc: "images/products/9.png",
    price: 4000
}, {
    ID: "1_1_3",
    categoryId: "1_1",
    name: "Monitors"
}, {
    ID: "1_1_3_1",
    categoryId: "1_1_3",
    name: "19\"",
}, {
    ID: "1_1_3_1_1",
    categoryId: "1_1_3_1",
    name: "DesktopLCD 19",
    iconSrc: "images/products/10.png",
    price: 160
}, {
    ID: "1_1_4",
    categoryId: "1_1",
    name: "Projectors"
}, {
    ID: "1_1_4_1",
    categoryId: "1_1_4",
    name: "Projector Plus",
    iconSrc: "images/products/14.png",
    price: 550
}, {
    ID: "1_1_4_2",
    categoryId: "1_1_4",
    name: "Projector PlusHD",
    iconSrc: "images/products/15.png",
    price: 750
}
];