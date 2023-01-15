'use strict';

const krequest = function () { };

krequest.parseData = (data) => {
    const stringData = [];
    for (let item in data) {
        let name = item !== 'action' ? `${item}_param` : item;
        stringData.push(`${name}=` + data[item]);
    }

    return stringData.join('&');
};

krequest.send = function ({ method, body, uri, headers, callbacks }) {
    return new Promise((resolve, reject) => {
        //try {
        const request = new XMLHttpRequest();

        if (!request) {
            const messageSupport = 'Navigator does not support XMLHttpRequest';
            console.error(Error(messageSupport));
            reject(new Response('error request.'));

            return;
        }

        if (typeof uri === 'undefined' && !uri) {
            uri = window.location.pathname;
        }

        request.open(method, uri, true);

        request.onloadstart = function () {
            if (typeof callbacks.onstart === 'function') {
                callbacks.onstart();
            }
        };

        request.onreadystatechange = function () {
            if (request.readyState === XMLHttpRequest.DONE) {
                if (request.status === 200) {
                    resolve(new Response(request.response));
                }
            }
        };

        request.onprogress = function () {
            //console.log('onprogress');
            if (typeof callbacks.onprogress === 'function') {
                callbacks.onprogress();
            }
        };

        request.onload = function () {
            //console.log('onload');
        };

        request.onloadend = function () {
            //console.log('onloadend');
        };

        request.onerror = function (e) {
            resolve(new Response('error request.'));
        };

        request.onabort = function () {
            //console.log('onabort');
        };

        let isRequestform = false;

        if (headers && headers.length > 0) {
            for (let h of headers) {
                if (h.name && h.value) {
                    request.setRequestHeader(h.name, h.value);

                    if (h.value.includes('application/x-www-form-urlencoded')) {
                        isRequestform = true;
                    }
                }
            }
        } else {
            request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        }

        request.setRequestHeader('Cache-Control', 'no-cache'); //para no almacenar en cache la respuesta

        if (isRequestform) {
            request.send(this.parseData(body));
        } else {
            request.send(body);
        }
        //} catch {
        //    reject('problem request kk.');
        //}
    });
};

window.KR = window.KRequest = window.krequest = krequest;