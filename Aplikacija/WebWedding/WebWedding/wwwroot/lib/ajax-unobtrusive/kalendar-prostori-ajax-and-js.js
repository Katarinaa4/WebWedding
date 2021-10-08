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
                            eventClick: function (info) {
                                var eventObj = info.event;
                                var modalObrisiDatum = document.getElementById('modalObrisiDatum');
                                var span = document.getElementById('m4c');

                                document.getElementById('datumId').value = eventObj.id; //value hidden input polja za datumId postace id eventa
                                document.getElementById('datumTip').value = eventObj.groupId; //value hidden input polja za datumTip postace tip: rezervisano ili zakazano

                                modalObrisiDatum.style.display = "block";
                                modalObrisiDatum.style.visibility = "visible";

                                span.onclick = function () {
                                    modalObrisiDatum.style.display = "none";
                                }
                               /* window.onclick = function (event) {
                                    if (event.target == modalObrisiDatum) {
                                        modalObrisiDatum.style.display = "none";
                                    }
                                }*/

                            },
                            dateClick: function (info) {
                                var modal = document.getElementById('myModal');
                                var span = document.getElementById('m1c');
                                var btnDodajRez = document.getElementById('dodajRez');
                                var btnDodajZak = document.getElementById('dodajZak');
                                var naslov = document.getElementById('naslov');

                                naslov.innerHTML = "Kliknuli ste na datum " + info.dateStr;

                                modal.style.display = "block";

                                span.onclick = function () {
                                    modal.style.display = "none";
                                }


                                btnDodajRez.onclick = function () {

                                    var modalDodajRez = document.getElementById('modalDodajRez');
                                    var span = document.getElementById('m2c');
                                    document.getElementById('datumRez').value = info.dateStr; //value hidden input polja postace izabrani datum

                                    modalDodajRez.style.display = "block";
                                    span.onclick = function () {
                                        modalDodajRez.style.display = "none";
                                    }


                                }

                                btnDodajZak.onclick = function () {

                                    var modalDodajZak = document.getElementById('modalDodajZak');
                                    var span = document.getElementById('m3c');
                                    document.getElementById('datumZak').value = info.dateStr; //value hidden input polja postace izabrani datum

                                    modalDodajZak.style.display = "block";
                                    span.onclick = function () {
                                        modalDodajZak.style.display = "none";
                                    }


                                }
                            },
                            events: events
                        });

                        calendar.render();

                    }

                })