ko.bindingHandlers.myKendoDatepicker = {
    init: function(element, valueAccessor, allBindingsAccessor) {

        //initialize datepicker with some optional options
        var options = allBindingsAccessor().datepickerOptions || {};
        var datepicker = $(element).kendoDatePicker(options).data('kendoDatePicker');

        // populate changes from Kendo UI world to Knockout world
        datepicker.bind("change", function() {

            var value = datepicker.value();
            var observable = valueAccessor();
            observable(value);
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function() {
            datepicker.destroy();
        });
    },

    update: function(element, valueAccessor) {

        //update the control when the view model changes
        var value = ko.utils.unwrapObservable(valueAccessor());
        var datepicker = $(element).data('kendoDatePicker');
        if (typeof value == "string") {
            value = new Date(value);
        }
        datepicker.value(value);
    }
};