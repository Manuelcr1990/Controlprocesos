var CPPlugins = (function () {
    return {
        InitDateTimePickers: function () {
            $('.bs3DateTimePicker').datetimepicker({locale: 'es', format: 'yyyy-MM-dd HH:mm:ss'})
        }
    }
}())