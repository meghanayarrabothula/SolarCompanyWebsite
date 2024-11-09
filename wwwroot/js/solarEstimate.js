document.addEventListener("DOMContentLoaded", () => {
    const apiUrl = '/api/location/solarEstimate?address=13802+heritage+club+drive';

    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            // Update location data
            document.getElementById("address").textContent = "13802 Heritage Club Drive";
            document.getElementById("latitude").textContent = data.center.latitude;
            document.getElementById("longitude").textContent = data.center.longitude;

            // Update solar data
            const imageryDate = `${data.imageryDate.year}-${data.imageryDate.month}-${data.imageryDate.day}`;
            document.getElementById("imagery-date").textContent = imageryDate;
            document.getElementById("postal-code").textContent = data.postalCode;
            document.getElementById("state").textContent = data.administrativeArea;
            document.getElementById("region-code").textContent = data.regionCode;

            // Update solar potential data
            document.getElementById("max-array-panels").textContent = data.solarPotential.maxArrayPanelsCount;
            document.getElementById("max-array-area").textContent = data.solarPotential.maxArrayAreaMeters2;
            document.getElementById("max-sunshine-hours").textContent = data.solarPotential.maxSunshineHoursPerYear;
            document.getElementById("carbon-offset").textContent = data.solarPotential.carbonOffsetFactorKgPerMwh;
        })
        .catch(error => {
            console.error("Error fetching solar estimate data:", error);
            // Handle errors, e.g., show an error message on the page
        });
});
