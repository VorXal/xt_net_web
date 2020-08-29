import './Service.js'; 
const service = new Service();
const plusBtn = document.getElementsByClassName('plus')[0];
const modalAdd = document.getElementsByClassName('modal-add')[0];
const modalChange = document.getElementsByClassName('modal-change')[0];
const closeAddBtn = document.getElementById('close-add');
const closeChangeBtn = document.getElementById('close-change');
const addBtn = document.getElementById('add-new');
const saveBtn = document.getElementById('save');
const main = document.getElementById('main');
let nameField = document.getElementById('name');
let contentField = document.getElementById('content');
const deleteBtns = document.getElementsByClassName('delete-btn');
let items = document.getElementsByClassName('item');

plusBtn.addEventListener("click", () => {
    modalAdd.style.display = "block";
    nameField.value = '';
    contentField.value = '';
}, false);

closeAddBtn.addEventListener("click", () => {
    modalAdd.style.display = "none";
}, false)

closeChangeBtn.addEventListener("click", () => {
    modalChange.style.display = "none";
}, false)

addBtn.addEventListener("click", () => {
    let name = nameField.value,
        content = contentField.value;
    if(name.trim() === '' && content.trim() === ''){
        console.log('Не-а, не добавлю я пустую заметку');
    }
    else{
        addNewItem(name, content);
    }
    modalAdd.style.display = "none";
});

save.addEventListener("click", () => {
    let name = nameField.value,
        content = contentField.value;
    if(name.trim() === '' && content.trim() === ''){
        console.log('Не-а, не добавлю я пустую заметку');
    }
    else{
        addNewItem(name, content);
    }
    modalChange.style.display = "none";
});

function addNewItem(name, content){
    let id = service._id;
    service.add({'name': name, 'content': content});
    let tempMain = `<div id='item-${id}' class="item">
                    <div class="item-name">${name}</div>
                    <div class="item-content">${content}</div>
                    <button class="delete-btn"><img src="icons/delete.svg"></button>
                    </div>`;
    main.innerHTML = tempMain + main.innerHTML; 

    for (let i = 0; i < deleteBtns.length; i++) {
        deleteBtns[i].addEventListener("click", () => {
            event.stopImmediatePropagation();
            deleteItem(deleteBtns[i].parentNode);
        }, false);
    }

    for (let i = 0; i < items.length; i++) {
        items[i].addEventListener("click", () => {
            changeItem(items[i]);
        }, false);
    }
    console.log('Done');
}

function deleteItem(htmlObject){
    let idHtml = htmlObject.id;
    let idService = idHtml.slice(idHtml.indexOf('-') + 1);

    let flag = confirm("Ты серьезно?");

    if(flag){
        service.deleteById(+idService);
        htmlObject.remove();
    }
    else{
        console.log('Удаление не подтверждено');
    }
}

function changeItem(item){
    modalChange.style.display = "block";
    addBtn.innerText = 'Сохранить';
    nameField = item.getElementsByClassName('item-name')[0];
    contentField = item.getElementsByClassName('item-content')[0];
    //nameField = '';
    //contentField = '';
    addBtn.innerText = 'Создать';
}
