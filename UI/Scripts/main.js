document.addEventListener('DOMContentLoaded', () => {
    generate();
});

const fetchCode = () => {
    let interval;
    const onstart = () => {
        let counter = 1;

        interval = setInterval(() => {
            if (counter === 3) {
                showLoading(true);
                clearInterval(interval);
            }

            counter++;
        }, 1000);
    };

    const onprogress = () => {
        if (interval) {
            clearInterval(interval);
        }
    };

    const response = KRequest.send({
        method: 'post', body: { action: 'Test' }, callbacks: { onstart, onprogress }, headers: [
            { name: 'Content-Type', value: 'application/x-www-form-urlencoded' }
        ]
    }).then(response => response.json()).catch(err => err.json());

    return response;
};

const generate = async () => {
    try {
        const response = await fetchCode();

        if (response.status === 'ok' && response.result && typeof response.result !== 'undefined' && response.result !== '') {
            document.getElementById('qrcode').src = JSON.parse(response.result).codeqr;

            showElementCodeQR(true);
            showLoading(false);
        }
    } catch (err) {
        showLoading(true);
        console.log(err);
    }

    setTimeout(async () => {
        await generate();
    }, 1000);
};

const showLoading = (show) => {
    const loading = document.querySelector('.loading-qrcode');
    if (loading) {
        if (show) {
            showElementCodeQR(false);
            loading.classList.remove('display-none');
        } else {
            loading.classList.add('display-none');
        }
    }
};

const showElementCodeQR = (show) => {
    const qrcode = document.getElementById('qrcode');

    if (qrcode) {
        if (show) {
            qrcode.classList.remove("display-none");
        } else {
            qrcode.classList.add("display-none");
            qrcode.src = null;
        }
    }
};