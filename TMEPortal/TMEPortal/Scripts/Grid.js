$(function () {
    var dataGrid = $("#gridContainer").dxDataGrid({
        dataSource: weekData,
        allowColumnResizing: true,
        columnAutoWidth: true,
        editing: {
            mode: "batch",
            allowUpdating: true,
            allowDeleting: true
        }, 
  
        columns: [
            {
                dataField: "Articulo"
                , allowEditing: false
            },
            {
                dataField: "Descripcion"
                , allowEditing: false
            },
            {
                dataField: "Cantidad",
                allowEditing: true
            },
            {
                dataField: "Clasificacion"
                , allowEditing: false
            },
            {
                dataField: "Color",
                caption: "Codigo del Color",
                 allowEditing: false
            },
            {
                dataField: "ColorCodigo",
                caption: "Acabado"
                , allowEditing: false
            },
            {
                dataField: "Largo"
                , allowEditing: false
            },
            {
                dataField: "Ancho"
                , allowEditing: false
            },
            {
                dataField: "Modelo"
                , allowEditing: false
            }
        ],
       
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
            mode: "virtual"
        },
        paging: {
            pageSize: 10
        },
       
        summary: {
            totalItems: [{
                column: "Articulo",
                summaryType: "count"
                

            }, {
                column: "Cantidad",
                summaryType: "sum"
            }]
        },
       /* onEditingStart: function (e) {
            console.log("onEditingStart");
            console.log(e);
            dataGrid.saveEditData();
            var Data = {};
            Data.Articulo = e.key.Articulo;
            Data.Cantidad = e.key.Cantidad;
            
            $.ajax({
                url: "/ProductosPortal/GridEdit",
                method: "POST",
                type: "POST",
                data: Data,
                success: function () {

            
                }
            })


        },*/
        
        onRowUpdating: function (e) {
             console.log("RowUpdating");
             console.log(e);
             //dataGrid.saveEditData(); 
            var Data = {};
            Data.Articulo = e.key.Articulo;
            Data.Cantidad = e.newData.Cantidad;

             $.ajax({
                 url: "/ProductosPortal/GridEdit",
                 method: "POST",
                 type: "POST",
                 data: Data,
                 success: function () {


                 }
             })


         },
         onRowRemoved: function (e) {
             console.log("RowRemoved");
             console.log(e);
         
             var Data = {};
             Data.Articulo = e.key.Articulo;
             Data.Cantidad = e.key.Cantidad;

             $.ajax({
                 url: "/ProductosPortal/RowDeleted",
                 method: "POST",
                 type: "POST",
                 data: Data,
                 success: function () {


                 }
             })


        },
        onCellPrepared: function (e) {
            if (e.rowType === "data" && e.column.command === "edit") {
                var isEditing = e.row.isEditing,
                    $links = e.cellElement.find(".dx-link");

                $links.text("");

                if (isEditing) {
                    $links.filter(".dx-link-save").dxButton({
                        icon: "save"
                    });
                    $links.filter(".dx-link-cancel").dxButton({
                        icon: "revert"
                    });
                } else {
                    $links.filter(".dx-link-edit").dxButton({
                        icon: "edit"
                    });

                    $links.filter(".dx-link-delete").dxButton({
                        icon: "trash",
                    });
                }
            }
        },

    }).dxDataGrid("instance");
});
/*
$("#autoExpand").dxCheckBox({
    value: true,
    text: "Expand All Groups",
    onValueChanged: function (data) {
        dataGrid.option("grouping.autoExpandAll", data.value);
        
    }
});

*/

var products = [];