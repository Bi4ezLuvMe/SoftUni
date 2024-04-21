function solve() {
   const addButtonElements = document.getElementsByClassName('add-product');
   const checkoutButtonElement = document.getElementsByClassName('checkout')[0];
   const textAreaElement = document.getElementsByTagName('textarea')[0];
   let totalPrice =0;
   let items = new Set();
   Array.from(addButtonElements)
   .forEach(button=>
      button.addEventListener('click',()=>{
     const name = button.parentElement.parentElement.getElementsByClassName('product-title')[0].textContent;
     const price = button.parentElement.parentElement.getElementsByClassName('product-line-price')[0].textContent;
     totalPrice+=Number(price);
     items.add(name);
    textAreaElement.textContent += `Added ${name} for ${price} to the cart.\n`
   }));
 checkoutButtonElement.addEventListener('click',()=>{
   Array.from(addButtonElements).forEach(x=>x.disabled = true);
  checkoutButtonElement.disabled =true;
  let itemsText=Array.from(items).join(', ');
  textAreaElement.textContent+=`You bought ${itemsText} for ${totalPrice.toFixed(2)}.`
 });
}