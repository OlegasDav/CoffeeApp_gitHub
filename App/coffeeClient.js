const baseUrl = "https://localhost:5001/coffee";

async function getCoffeeItems() {
    const response = await fetch(baseUrl);

    return response.json();
}

async function createCoffeeItem(coffeeItem) {
    let response = await fetch(baseUrl, {
        method: "POST",
        body: coffeeItem,
        headers: {"accept-language": "fr"}
    });

    const parsedJson = await response.json();

    if (parsedJson.errors != null) {
        var errorMessage = '';

        for (const i in parsedJson.errors) {
            for (let j = 0; j < parsedJson.errors[i].length; j++) {
                errorMessage += parsedJson.errors[i][j] + ".\n";
            }
        }

        throw new Error(errorMessage);
    }

    return parsedJson;
}

async function deleteCoffeeItem(id) {
    await fetch(`${baseUrl}/${id}`, {
        method: "DELETE"
    });
}
