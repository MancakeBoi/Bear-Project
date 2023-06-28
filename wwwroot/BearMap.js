
import 'https://api.mapbox.com/mapbox-gl-js/v2.15.0/mapbox-gl.js';

import "https://api.mapbox.com/search-js/v1.0.0-beta.16/web.js";
 

export function setToken(Token)
{
  window.MapboxAPIToken = Token;
}
let map;
var currentMarkers=[];
export function addMap(element) {
    mapboxgl.accessToken = window.MapboxAPIToken;
    map = new mapboxgl.Map(
        {
            container: element,
            style: 'mapbox://styles/mapbox/streets-v11',
            center: [-149.84997297110655, 61.21984016240975],
            zoom: 9
        }
    )
    return map;
}
let marker;
let popup;
let text
let text1
export function addBear(lat , lng , type , encounter,adult,cub,time)
{
    //popup
    text = "Type: " + type + "\nEncounter: " + encounter + "\nAdults: " + adult + "\nCubs: " + cub;
    text1 = "Type: " + type
     popup = new mapboxgl.Popup()
     
    .setHTML("<h7>"+"Time: "+time+"</h7><div>"+"Type: " + type +"</div><div>"+"Encounter: " + encounter+"</div><div>"+"Adults: " + adult+"</div><div>"+"Cubs: " + cub+"</div>");
    marker = new mapboxgl.Marker({
        draggable: false})
        .setLngLat([lat,lng])
        .setPopup(popup)
        .addTo(map)
    currentMarkers.push(marker);
    
    
    
        
         
    
   
}
export function removeMarkers()
{
    if (currentMarkers!==null) {
        for (var i = currentMarkers.length - 1; i >= 0; i--) {
          currentMarkers[i].remove();
        }
    }
}