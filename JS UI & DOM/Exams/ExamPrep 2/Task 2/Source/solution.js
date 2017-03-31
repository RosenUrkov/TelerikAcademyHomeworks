function solve() {
    $.fn.datepicker = function() {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function() {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function() {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        var date = new Date(),
            $this = $(this)
            .on('click', function() {
                var $target = $datePicker
                    .find('.datepicker-content');

                if (!$target.hasClass('datepicker-content-visible')) {
                    $target.addClass('datepicker-content-visible');
                }
            }),
            $datePicker = $('<div>')
            .addClass('datepicker-wrapper')
            .append($this.addClass('datepicker'))
            .appendTo($(document.body).find('div').first())
            .append(
                $('<div>')
                .addClass('datepicker-content')
                .addClass('datepicker-content-visible')
                .append($('<div>').addClass('controls'))
                .append($('<table>').addClass('calendar'))
                .append(
                    $('<div>')
                    .addClass('current-date')
                    .append(
                        $('<a>')
                        .attr('href', '#')
                        .addClass('current-date-link')
                        .html(date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear())
                    )
                )
            )
            .on('click', '.current-month', function() {
                removeVisibility();
                $this.val($(this).html() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear());
            }),
            $controls = $datePicker
            .find('.controls')
            .append($('<button>').addClass('btn').html('<'))
            .append($('<div>').addClass('current-month'))
            .append($('<button>').addClass('btn').html('>'));

        $datePicker.find('.calendar').replaceWith(fillCalendar(date));
        removeVisibility();

        $('.btn').on('click', function() {
            if ($(this).html() === '&lt;') {
                date.setMonth(date.getMonth() - 1);
            } else if ($(this).html() === '&gt;') {
                date.setMonth(date.getMonth() + 1);
            } else {
                return;
            }

            $datePicker.find('.calendar').replaceWith(fillCalendar(date));
        });

        $('.current-date-link').on('click', function() {
            removeVisibility();
            $this.val(date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear());
        });

        function fillCalendar(date) {
            var date = new Date(date),
                $newCalendar = $('<table>').addClass('calendar');

            $datePicker.find('.current-month')
                .html(date.getMonthName() + ' ' + date.getFullYear());

            date.setDate(1);
            var firstDayOfWeek = date.getDay(),
                firstDay = date.getDate() - 1;

            date.setMonth(date.getMonth() + 1);
            date.setDate(0);
            var thisMonthDays = date.getDate() + 1;

            date.setDate(0);
            var lastMonthDays = date.getDate() + 1,
                firstOnCalendar = firstDayOfWeek === 0 ? lastMonthDays - 7 : lastMonthDays - firstDayOfWeek,
                currentDay = firstOnCalendar,
                daysOfMonth = lastMonthDays,
                dayClass = 'another-month';

            for (var i = 0, length = 7; i < length; i += 1) {
                var $tr = $newCalendar.append($('<tr>')).find('tr').eq(i);
                for (var j = 0, length = 7; j < length; j += 1) {
                    if (i === 0) {
                        $tr.append($('<th>').html(WEEK_DAY_NAMES[j]));
                        continue;
                    }

                    $tr.append($('<td>').html(currentDay).addClass(dayClass));

                    if ((currentDay + 1) % daysOfMonth === 0) {
                        currentDay = firstDay;
                        daysOfMonth = thisMonthDays;
                        dayClass = dayClass === 'current-month' ? 'another-month' : 'current-month';
                    }

                    currentDay = (currentDay + 1) % daysOfMonth;
                }
            }

            return $newCalendar;
        }

        function removeVisibility() {
            $datePicker
                .find('.datepicker-content')
                .removeClass('datepicker-content-visible');
        }

        return $this;
    }
}