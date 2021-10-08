window.onload=function(){

var prostoriLista = document.getElementById('prostori');
        var load=(function (){
		var prostoriLista = document.getElementById('prostori');
        var prostorId = prostoriLista.options[prostoriLista.selectedIndex].value; //id izabranog prostora
        var menijiLista = document.getElementById('meniji');
		
        $.ajax({
            type: 'GET',
            url: '/api/Meni',
            success: function (data) {
                var i;
                
                
                //popuni listu sa menijima samo iz izabranog restorana
                for (i = 0; i < data.length; i++) {
					if(data[i].mojProstor.id==prostorId){
						var option=document.createElement("option");
						option.value=data[i].id;
						option.text=data[i].naziv;
						menijiLista.add(option);						
					}
                }
				
				
            }
			
        })
	})();
    prostoriLista.onchange = function () {
		
		
		var prostoriLista = document.getElementById('prostori');
        var prostorId = prostoriLista.options[prostoriLista.selectedIndex].value; //id izabranog prostora
        var menijiLista = document.getElementById('meniji');
		
        $.ajax({
            type: 'GET',
            url: '/api/Meni',
            success: function (data) {
                var i;
                //brise sve elemente iz liste
                for (i = menijiLista.options.length; i >= 0; i--) {
                    menijiLista.options[i] = null;
                }
                
                //popuni listu sa menijima samo iz izabranog restorana
                for (i = 0; i < data.length; i++) {
					if(data[i].mojProstor.id==prostorId){
						var option=document.createElement("option");
						option.value=data[i].id;
						option.text=data[i].naziv;
						menijiLista.add(option);						
					}
                }
				
				
            }
			
        })
    

		
		}

}