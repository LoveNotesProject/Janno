mdc.autoInit.mdcAutoInit();

let topAppBarElement = document.querySelector('.mdc-top-app-bar');
let topAppBar = mdc.topAppBar.MDCTopAppBar.attachTo(topAppBarElement);
let drawer = mdc.drawer.MDCDrawer.attachTo(document.querySelector(".mdc-drawer"));
let grids = document.querySelectorAll(".mdc-layout-grid");

topAppBar.setScrollTarget(document.querySelector('main'));
topAppBar.listen('MDCTopAppBar:nav', () => {
  if (drawer.open) {
    drawer.open = false;
    setCookie('showDrawer', false, 7);

    if (window.innerWidth >= 480) {
      setGridWidth("80%");
    } else {
      setGridWidth("100%");
      showMobileSection();
    }
  } else {
    drawer.open = true;
    setCookie('showDrawer', true, 7);
    setGridWidth("100%");
    if (window.innerWidth <= 480) {
      hideMobileSection();
    }
  }

  calcLayout();

});

// Init Button Ripple Effect

let buttonsRipple = document.querySelectorAll('.mdc-button');
if (buttonsRipple != null) {
  buttonsRipple.forEach((e) => {
    new mdc.ripple.MDCRipple(e);
  });
}


// Load listener
window.addEventListener("DOMContentLoaded", () => {
  if (getCookie('showDrawer') === "true") {
    if (window.innerWidth >= 480) {
      drawer.open = true;
    } else {
      drawer.open = false;
      setCookie('showDrawer', false, 7);
    }

    setGridWidth("100%");
  } else {
    drawer.open = false;
    if (window.innerWidth >= 480) {
      setGridWidth("80%");
    } else {
      setGridWidth("100%");
    }
  }

  calcLayout();
});

// Drawer Listener
let list2 = new mdc.list.MDCList(document.querySelector('.mdc-drawer .mdc-list'));
list2.listen('MDCList:action', (e) => {
  setCookie('drawerActiveIndex', e.detail.index, 1);
});

// Scroll listener
document.querySelector('main').addEventListener('scroll', () => {
  topAppBarElement.style.top = "0";
});

// Resize listener
window.addEventListener("resize", () => {
  if (drawer.open === true) {
    drawer.open = false;
    setCookie("showDrawer", false, 7);
  }

  if (window.innerWidth >= 480) {
    setGridWidth("80%");
  } else {
    setGridWidth("100%");
    showMobileSection();
  }
});

function setGridWidth(width) {
  grids.forEach((e) => {
    e.style.maxWidth = width;
  })
}

function showMobileSection() {
  document.querySelector('section.mdc-top-app-bar__section.mdc-top-app-bar__section--align-end').style.display = ""
}

function hideMobileSection() {
  document.querySelector('section.mdc-top-app-bar__section.mdc-top-app-bar__section--align-end').style.display = "none"
}

// region Cookie

function getCookie(name) {
  let v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
  return v ? v[2] : null;
}

function setCookie(name, value, days) {
  let date = new Date;
  date.setTime(date.getTime() + 24 * 60 * 60 * 1000 * days);
  document.cookie = name + "=" + value + ";path=/;expires=" + date.toUTCString();
}

function deleteCookie(name) {
  setCookie(name, '', -1);
}

// endregion Cookie

function calcLayout() {
  let mainGridLayouts = document.querySelectorAll('main .mdc-layout-grid:not(.mdc-layout-grid-dialog)');
  if (mainGridLayouts != null && mainGridLayouts.length > 0) {
    mainGridLayouts[mainGridLayouts.length - 1].style = 'padding-bottom:128px';

    if (getCookie('showDrawer') === "true") {
      mainGridLayouts.forEach((e) => {
        if(e.hasAttribute("decrease-disable") === true) return;
        if (e.hasAttribute('decrease')) {
          if (e.getAttribute('decrease') === "true") {
            e.setAttribute('style', 'padding: 0 0 128px 0; max-width:100%');
          } else {
            e.setAttribute('style', 'max-width:100%');
          }
        } else {
          e.setAttribute('style', 'max-width:100%');
        }
      });
    }
  }
}

// region Ajax

function sendAjaxGet(url) {
  return fetch(url, {
    method: "GET",
    headers: {
      "Content-Type": "application/json"
    },
    cache: 'no-cache',
    credentials: 'include'
  }).then(function (response) {
    return response.json();
  }).then(function (json) {
    return json;
  }).catch(error => {
    console.error(error);
  });
}

function sendAjaxPost(url, data) {
  return fetch(url, {
    method: "POST",
    headers: {
      'Accept': 'application/json',
      'Content-type': 'application/json',
      'XSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
    },
    cache: 'no-cache',
    body: data,
    credentials: 'include'
  }).then(function (response) {
    let contentType = response.headers.get("content-type");
    if (contentType && contentType.indexOf("application/json") !== -1) {
      return response.json();
    } else {
      return response.text();
    }
  }).then(function (json) {
    return json;
  }).catch(error => {
    console.error(error);
  });
}

function sendAjaxGetHtml(url) {
  return fetch(url, {
    method: "GET",
    headers: {
      "Content-Type": "application/html"
    },
    cache: 'no-cache',
    credentials: 'include'
  }).then(function (response) {
    return response.text();
  }).then(function (text) {
    return text;
  }).catch(error => {
    console.error(error);
  });
}

function sendAjaxPostHtml(url, data) {
  return fetch(url, {
    method: "POST",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/html',
      'XSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
    },
    cache: 'no-cache',
    body: data,
    credentials: 'include'
  }).then(function (response) {
    return response.text();
  }).then(function (text) {
    return text;
  }).catch(error => {
    console.error(error);
  });
}

// endregion Ajax

// region Misc

let snackbar = new mdc.snackbar.MDCSnackbar(document.querySelector('.mdc-snackbar'));

function showToast(text) {
  snackbar.labelText = text;
  snackbar.open();
}

let _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];

/**
 * @return {boolean}
 */
function ValidateImageExtension(fileName) {
  if (fileName.length > 0) {
    for (let j = 0; j < _validFileExtensions.length; j++) {
      let extension = _validFileExtensions[j];
      if (fileName.substr(fileName.length - extension.length, extension.length).toLowerCase() === extension.toLowerCase()) {
        return true;
      }
    }

    showToast("Der Dateityp ist nicht erlaubt!");
    return false;
  }

  return false;
}

Date.prototype.getFullMinutes = function () {
  if (this.getMinutes() < 10) {
    return '0' + this.getMinutes();
  }
  return this.getMinutes();
};

function insertHTML(selector, text) {
  let selectorElement = document.querySelector(selector);
  selectorElement.innerHTML = text;
  Array.from(selectorElement.querySelectorAll("script")).forEach(oldScript => {
    const newScript = document.createElement("script");
    Array.from(oldScript.attributes)
      .forEach(attr => newScript.setAttribute(attr.name, attr.value));
    newScript.appendChild(document.createTextNode(oldScript.innerHTML));
    oldScript.parentNode.replaceChild(newScript, oldScript);
  });
}


// endregion