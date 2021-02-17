$(document).ready(viewDataTable);
   function viewDataTable() {
       
        return $.ajax({ 
             type: 'POST',
             url: '/Productos/chargeParameters',
             dataType: 'json',
             success: function (data) {
 
                 var sd = data;
                 cargaTabla(sd);
 
             }, error: function (xhr, status) {
 
                 alert('Disculpe, existió un problema');
 
             }
             //async: false
         });
     }
 
 
    function cargaTabla(response) {
        var table = $('#tablePasiente').DataTable({
             "destroy": true,
             "data": response,
             "columns": [
                 { "data": "Codiprod", "autoWidth": true },
                 { "data": "Nombprod", "autoWidth": true },
                 { "data": "Descprod", "autoWidth": true },
                 { "data": "Valoprod", "autoWidth": true },
                 { "defaultContent": "<a type='button' class='editar btn btn-warning'> <i class='fa fa-business-time fa-w-20'></i></a> <button type='button' class='eliminar btn btn-danger'><span class='glyphicon glyphicon-trash'></span></button>" }
             ]
         });
    }

//documento.crewelement