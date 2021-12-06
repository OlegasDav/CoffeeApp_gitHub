// variables
var enterCoffeeItem = document.getElementById('enter');
var title = document.getElementById('title');
var price = document.getElementById('price');
var uploadedImage = document.getElementById('uploadImage');
var coffeeList = document.getElementById("coffeeItems");
var addForm = document.getElementById('addForm');
var alertDanger = document.querySelector('.alert-danger');

function CreateCard(coffeeItem) {

  return `
  <div class="col-12 col-sm-6 col-lg-4 col-xl-3 mb-4">
    <div class="border border-1 shadow-sm p-3 rounded coffee-item" data-id=${coffeeItem.id}>
      <img src="data:image/png;base64, ${coffeeItem.image}" alt="Card image cap">
      <h4 class="mt-3 input-name">${coffeeItem.name}</h4>
      <ul class="list-group list-group-flush">
        <li class="list-group-item"><strong>Price:</strong> €${coffeeItem.price} </li>
      </ul>
      <button type="button" class="btn btn-danger delete">Delete</button>
    </div>
  </div>`;
}

// Get all coffee-item cards
window.onload = async () => {
  const coffeeItems = await getCoffeeItems();

  coffeeItems.forEach(coffeeItem => {
    coffeeList.innerHTML += CreateCard(coffeeItem);
  });
}

// Validation
document.addEventListener('input', () => {
  if (title.value) {
    title.classList.remove('is-invalid');
  }

  if (price.value) {
    price.classList.remove('is-invalid');
  }
  
  if (uploadedImage.value) {
    uploadedImage.classList.remove('is-invalid');
  }
});


enterCoffeeItem.addEventListener('click', async (e) => {
  if (title.value == '') {
    title.classList.add('is-invalid');
  }

  if (price.value == '') {
    price.classList.add('is-invalid');
  }

  if (uploadedImage.value == '') {
    uploadedImage.classList.add('is-invalid');
  }
  
  if (title.value != '' && price.value != '' && uploadedImage.value != '') {

    var priceToChange = price.value;
    priceToChange = priceToChange.replace('.', ',');

    var coffeeItem = new FormData();
    coffeeItem.append('name', title.value);
    coffeeItem.append('price', priceToChange);
    coffeeItem.append('image', uploadedImage.files[0]);

    try {
      await createCoffeeItem(coffeeItem);
      alertDanger.classList.add("d-none");
      enterCoffeeItem.setAttribute("data-bs-dismiss", "modal");
      addForm.reset();
      location.reload();
    } catch (error) {
      alertDanger.classList.remove("d-none");
      alertDanger.innerHTML = error.message;
    }
  }
});

// Coffee-item card actions
document.addEventListener("click", async function (e) {
  if (e.target.matches(".delete")) {
    var id = e.target.closest(".coffee-item").getAttribute("data-id");
    await deleteCoffeeItem(id);
    e.target.closest(".coffee-item").remove();
    location.reload();
    return;
  }
});
