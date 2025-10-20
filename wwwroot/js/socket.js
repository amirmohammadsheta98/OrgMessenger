import { io } from "https://cdn.socket.io/4.7.2/socket.io.esm.min.js";

//let socket = null;

window.connectSocket = async function (token, dotnetRef) {
    console.log("Connecting socket with token:", token);
    const socket = io("http://82.115.25.140:3000", {
        extraHeaders: {
            Authorization:
                "Bearer " + token,
        },
    });
    socket.on("connect", () => {
        console.log("connected to server");
    });


    socket.onAny((event, data) => {
        console.log("event:" + event, data);
        dotnetRef.invokeMethodAsync("OnEventReceived", event, JSON.stringify(data));
    });

    //socket.on("myInfo", (data) => {
    //    console.log("myInfo", data);
    //    dotnetRef.invokeMethodAsync("OnMyInfoReceived", data);

    //});

    //socket.on("getUsers", (data) => {
    //        console.log("getUsers:", data);
    //    dotnetRef.invokeMethodAsync("OnGetUsersReceived", data);
    //});
    //socket.on("privateChat", (data) => {
    //        console.log("privateChat:", data);
    //        //dotnetRef.invokeMethodAsync("OnPrivateChatReceived", data);
    //    });

    //socket = io("http://82.115.25.140:3000", {   
    //    transports: ["websocket"],
    //    extraHeaders: {                        
    //        authorization: "Bearer " + token
    //    },
    //    withCredentials: true
    //});

    //socket.on("connect", () => {
    //    console.log("Socket connected:", socket.id);

    //    socket.on("myInfo", (data) => {
    //        console.log("myInfo:", data);
    //        dotnetRef.invokeMethodAsync("OnMyInfoReceived", data);
    //    });

    //    socket.on("getUsers", (data) => {
    //        console.log("getUsers:", data);
    //        dotnetRef.invokeMethodAsync("OnUsersReceived", data);
    //    });

    //    socket.on("privateChat", (data) => {
    //        console.log("privateChat:", data);
    //        dotnetRef.invokeMethodAsync("OnPrivateChatReceived", data);
    //    });
    //});

    //socket.on("connect_error", (err) => {
    //    console.error("Connection error:", err.message);
    //});

    //socket.onAny((event, data) => {
    //    console.log("EVENT:", event, data);
    //});
};
