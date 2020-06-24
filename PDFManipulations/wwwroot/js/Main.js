const url = 'D:/Freelance/pdf_viewer-master/pdf_viewer-master/pdf.pdf';

let pdfDoc = null,
  pageNum = 1,
  pageIsRendering = false,
  pageNumIsPending = null;

const scale = 1.5,
  canvas = document.querySelector('#pdf-render'),
  ctx = canvas.getContext('2d');

// Render the page
const renderPage = num => {
  pageIsRendering = true;

  // Get page
  pdfDoc.getPage(num).then(page => {
    // Set scale
    const viewport = page.getViewport({ scale });
    canvas.height = viewport.height;
    canvas.width = viewport.width;

    const renderCtx = {
      canvasContext: ctx,
      viewport
    };

    page.render(renderCtx).promise.then(() => {
      pageIsRendering = false;

      if (pageNumIsPending !== null) {
        renderPage(pageNumIsPending);
        pageNumIsPending = null;
      }
    });

    // Output current page
    document.querySelector('#page-num').textContent = num;
  });
};

// Check for pages rendering
const queueRenderPage = num => {
  if (pageIsRendering) {
    pageNumIsPending = num;
  } else {
    renderPage(num);
  }
};

// Show Prev Page
const showPrevPage = () => {
  if (pageNum <= 1) {
    return;
  }
  pageNum--;
  queueRenderPage(pageNum);
};

// Show Next Page
const showNextPage = () => {
  if (pageNum >= pdfDoc.numPages) {
    return;
  }
  pageNum++;
  queueRenderPage(pageNum);
};

var BASE64_MARKER = ';base64,';
    function convertDataURIToBinary(dataURI) {
      var base64Index = dataURI.indexOf(BASE64_MARKER) + BASE64_MARKER.length;
      var base64 = dataURI.substring(base64Index);
      var raw = window.btoa(unescape(encodeURIComponent(base64)));
      var rawLength = raw.length;
      var array = new Uint8Array(new ArrayBuffer(rawLength));

      for(var i = 0; i < rawLength; i++) {
        array[i] = raw.charCodeAt(i);
      }
      return array;
    }
var xhr = new XMLHttpRequest();
xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.open('GET', url, true);

    xhr.onload = function (e) {
        var response = e.target.response;
        var pdfAsArray = convertDataURIToBinary("data:application/pdf;base64, " + response);
        var pdfDocument;

     
        
         PDFJS
            .getDocument(pdfAsArray)
            .promise.then(pdfDoc_ => {
              pdfDoc = pdfDoc_;

              document.querySelector('#page-count').textContent = pdfDoc.numPages;

              renderPage(pageNum);
            })
            .catch(err => {
              // Display error
              const div = document.createElement('div');
              div.className = 'error';
              div.appendChild(document.createTextNode(err.message));
              document.querySelector('body').insertBefore(div, canvas);
              // Remove top bar
              document.querySelector('.top-bar').style.display = 'none';
            });


    };

    xhr.send();



// Get Document


// Button Events
document.querySelector('#prev-page').addEventListener('click', showPrevPage);
document.querySelector('#next-page').addEventListener('click', showNextPage);
