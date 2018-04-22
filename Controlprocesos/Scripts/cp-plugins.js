var CPPlugins = (function () {
    return {
        InitDateTimePickers: function () {
            $('.bs3DateTimePicker').datetimepicker({ locale: 'es', format: 'YYYY-MM-DD'})
        }
    }
}())