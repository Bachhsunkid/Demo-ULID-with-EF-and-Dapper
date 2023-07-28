const ulid = require("ulid");

// Generate a new ULID
const generatedULID = ulid.ulid();
console.log(generatedULID);

// The URL of the API
const myUlid = "01H6B8EN54WT5XND6MV95K86C9";
const apiUrl = `https://localhost:7296/api/Employee/id?id=01H6B8EN54WT5XND6MV95K86C9`;

// Fetch options
const fetchOptions = {
  method: "GET",
  headers: {
    Accept: "*/*",
  },
};

// Fetch request
fetch(apiUrl, fetchOptions)
  .then((response) => {
    if (!response.ok) {
      throw new Error("Network response was not ok");
    }
    return response.json();
  })
  .then((data) => {
    console.log(data);
  })
  .catch((error) => {
    console.error("Fetch error:", error);
  });
