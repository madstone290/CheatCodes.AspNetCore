interface ClientMessage {
    Content: string;
    IsBroadcast: boolean;
    Receiver: string;
    Sender: string;
}

interface ServerMessage {
    Type: string;
    Content: string;
    IsBroadcast: boolean;
    Sender: string;
    Receiver: string;
}



const index = function () {
    const userName = document.getElementById("userName") as HTMLInputElement;
    const server = document.getElementById("server") as HTMLInputElement;
    const connectButton = document.getElementById("connectButton") as HTMLButtonElement;
    const stateLabel = document.getElementById("stateLabel");
    const sendMessage = document.getElementById("sendMessage") as HTMLInputElement;
    const sendButton = document.getElementById("sendButton") as HTMLButtonElement;
    const chatLog = document.getElementById("chatLog");
    const closeButton = document.getElementById("closeButton") as HTMLButtonElement;
    let socket: WebSocket;

    let connectionUrl = "wss://localhost:7015/ws?username=";

    function getServerUrl() {
        return server.value;
    }

    function setElmentEnabled(enabled: boolean) {
        sendMessage.disabled = !enabled;
        sendButton.disabled = !enabled;
        closeButton.disabled = !enabled;
    }

    function disable() {
        setElmentEnabled(false);
    }

    function enable() {
        setElmentEnabled(true);
    }

    function updateState() {
        connectButton.disabled = true;
        userName.disabled = true;

        if (!socket) {
            disable();
        } else {
            switch (socket.readyState) {
                case WebSocket.CLOSED:
                    stateLabel.innerHTML = "Closed";
                    disable();
                    connectButton.disabled = false;
                    userName.disabled = false;
                    break;
                case WebSocket.CLOSING:
                    stateLabel.innerHTML = "Closing...";
                    disable();
                    break;
                case WebSocket.CONNECTING:
                    stateLabel.innerHTML = "Connecting...";
                    disable();
                    break;
                case WebSocket.OPEN:
                    stateLabel.innerHTML = "Open";
                    enable();
                    break;
                default:
                    stateLabel.innerHTML = "Unknown WebSocket State: " + htmlEscape(socket.readyState);
                    disable();
                    break;
            }
        }
    }

    function handleCloseClick() {
        if (!socket || socket.readyState !== WebSocket.OPEN) {
            alert("socket not connected");
        }
        socket.close(1000, "Closing from client");
    }

    function handleSendClick() {
        if (!socket || socket.readyState !== WebSocket.OPEN) {
            alert("socket not connected");
        }
        var data = sendMessage.value;

        const message: ClientMessage = {
            IsBroadcast: true,
            Sender: userName.value,
            Content: data,
            Receiver: ""
        };
        socket.send(JSON.stringify(message));

        sendMessage.value = "";
    }

    function handleConnectClick() {
        stateLabel.innerHTML = "Connecting";
        socket = new WebSocket(getServerUrl() + userName.value);

        socket.onopen = function (event) {
            updateState();
            console.log("socket opened", event);
        };

        socket.onclose = function (event) {
            updateState();
            chatLog.innerHTML += '<p>Connection closed: ' + htmlEscape(event.reason) + '</p>';
        };

        socket.onerror = () => updateState();

        socket.onmessage = function (event) {
            console.log(event.data);
            const serverMessage = JSON.parse(event.data) as ServerMessage;
            const { Type: type, Content: content, IsBroadcast: isBroadcast, Sender: sender } = serverMessage;

            if (content) {
                if (type === "System") {
                    const style = `style="text-align: left; color: red;"`;
                    const escapedContent = htmlEscape(content);
                    const html = `<p ${style}>${escapedContent}</p>`
                    chatLog.innerHTML += html;
                } else if (type === "Chat") {
                    const style = sender === userName.value ? `style="text-align: right;"` : `style="text-align: left;"`;
                    const escapedContent = htmlEscape(content);
                    const html = sender === userName.value ?
                        `<p ${style}>${escapedContent}</p>`
                        : `<p ${style}>${sender}: ${escapedContent}</p>`;
                    chatLog.innerHTML += html;
                }

            }
        };
    }

    function initialize() {
        server.value = connectionUrl;

        closeButton.onclick = handleCloseClick;
        sendButton.onclick = handleSendClick;
        connectButton.onclick = handleConnectClick;
    }

    function htmlEscape(str) {
        return str.toString()
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');
    }

    return {
        initialize
    };
}();

(window as any).Page = index;
window.onload = () => index.initialize();
