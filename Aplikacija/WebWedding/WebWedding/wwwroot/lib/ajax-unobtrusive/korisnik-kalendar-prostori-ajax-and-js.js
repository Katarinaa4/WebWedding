$(function () {
                    var events = [];
                    $.ajax({
                        type: 'GET',
                        url: '/api/ProstorRezervisani',
                        success: function (data) {
                            $.each(data, function (i, v) {

                                events.push({
                                    id: v.id,
                                    groupId: "rezervisano",
                                    title: v.mojProstor.naziv + ": rezervisano",
                                    start: v.datum,
                                    allDay: true,
                                    backgroundColor: "#fa9696",
                                    textColor: "white"
                                });
                            })
                        },
                        complete: function () {
                            $.ajax({
                                type: 'GET',
                                url: '/api/ProstorZakazani',
                                success: function (data) {
                                    $.each(data, function (i, v) {
                                        events.push({
                                            id: v.id,
                                            groupId: "zakazano",
                                            title: v.mojProstor.naziv + ": zakazano",
                                            start: v.datum,
                                            allDay: true,
                                            backgroundColor: "#f74364",
                                            textColor: "white"
                                        });
                                    })

                                    GenerateCalendar(events);
                                },
                                error: function (error) {
                                    alert('failer');
                                }
                            })
                        },
                        error: function (error) {
                            alert('failed');
                        }
                    })



                    function GenerateCalendar(events) {

                        var calendarEl = document.getElementById('calendar');

                        var calendar = new FullCalendar.Calendar(calendarEl, {
                            plugins: ['dayGrid','interaction'],                                                      
                            events: events
                        });

                        calendar.render();

                    }

                })