import 'https://api.mapbox.com/mapbox-gl-js/v2.15.0/mapbox-gl.js';

import "https://api.mapbox.com/search-js/v1.0.0-beta.16/web.js";

export function setToken(Token)
{
  window.MapboxAPIToken = Token;
}

let map;
let search;

export function addMapToElement(element) {
  mapboxgl.accessToken = window.MapboxAPIToken;
  map = new mapboxgl.Map({
    container: element,
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [-149.84997297110655, 61.21984016240975],
    zoom: 9
  });
  search = new MapboxSearchBox();
  search.accessToken = window.MapboxAPIToken;
  map.addControl(search);
  

  return map;

}

let marker;
export function addPoint() {
  marker = new mapboxgl.Marker({
    draggable: true
  })
    .setLngLat([-149.84997297110655, 61.21984016240975])
    .addTo(map);
  marker.on('dragend', onDragEnd);
  search.addEventListener('retrieve', (event) => {
    
    if (event.detail.features.length > 0) {
      let lnglat = event.detail.features[0].properties.coordinates
      marker.setLngLat([lnglat.longitude, lnglat.latitude])
      onDragEnd()
    }


  });
}

let dotNetHelper;
export function starter(value) {
  dotNetHelper = value;
}
function onDragEnd() {

  dotNetHelper.invokeMethodAsync("setLatLng", marker._lngLat.lat, marker._lngLat.lng)
}


let script;
export function complete() {
  script = document.getElementById('search-js');
  script.onload = function () {
    mapboxsearch.autofill({
      accessToken: 'pk.eyJ1IjoiY29ybWFjbXVuaSIsImEiOiJjbGo2ODFma3QwZ2hnM2VudmhtZDdkdDE3In0.eBN9mqTcdkVslx6iyAuyyw'
    });
  };
}
