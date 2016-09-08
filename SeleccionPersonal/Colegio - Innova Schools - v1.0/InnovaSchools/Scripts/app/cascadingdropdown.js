var moduloUsuario = (function () {

    function configuraDropDownEnCascada($seccion) {
        if ($seccion.length <= 0) return;
        $seccion.cascadingDropdown({
            selectBoxes: [
                {
                    selector: 'select.id_zona',
                    source: function (request, response) {
                        $.getJSON('/GenerarInformeEntrega/Zonas',
                            function (ciasLista) {
                                var cia = $seccion.find('input[type=hidden].id_zona').val();
                                var cias = $.map(ciasLista, function (item) {
                                    return {
                                        label: item.descripcion,
                                        value: item.id_zona,
                                        selected: item === cia
                                    }
                                });
                                response(cias);

                            });
                    },
                    onChange: function (event, value, requiredValues) {
                        if (value && value !== null) {
                            $seccion.find('input[type=hidden].id_zona').val(value);
                            
                        }
                    }
                },
                {
                        selector: 'select.id_tienda',
                        requires: ['select.id_zona'],
                        source: function (request, response) {
                            var zonaid = $seccion.find('input[type=hidden].id_zona').val();
                            //alert(zonaid)
                            $.getJSON('/GenerarInformeEntrega/Tiendas', { idzona: zonaid }, function (cuentasLista) {
                            //$.getJSON('/OrdenDespacho/Tiendas', request,
                            //    function (cuentasLista) {
                                    var cuenta = $seccion.find('input[type=hidden].id_tienda').val();
                                    var cuentas = $.map(cuentasLista, function (item) {
                                        return {
                                            label: item.descripcion,
                                            value: item.id_tienda,
                                            selected: item === cuenta
                                        }
                                    });
                                    response(cuentas);
                                });
                    },
                    onChange: function (event, value, requiredValues) {
                        if (value && requiredValues["id_zona"] !== null) {
                            $seccion.find('input[type=hidden].id_zona').val(requiredValues["id_zona"]);
                            $seccion.find('input[type=hidden].id_tienda').val(value);
                        }
                    }

                }
            ]
        });
    }

    return {
        vincularControles: function () {
            configuraDropDownEnCascada($('#usuario-ubigeo-dropdown'))
        }
    }

})();

$(function () {
    moduloUsuario.vincularControles();
})