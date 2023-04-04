import { useCallback, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useUserDispatch, useUserSelector } from "../../hooks/userHooks";
import { IChatChange } from "../../models/chat/IChatChange";
import { IChatCreate } from "../../models/chat/IChatCreate";
import { IChatNewMessages } from "../../models/chat/IChatNewMessages";
import { IUserChangeStatus } from "../../models/user/IUserChangeStatus";
import { IUserRead } from "../../models/user/IUserRead";
import { changeMessage, clearChat, createMessage, deleteMessage, getAllMessages } from "../../store/reducers/chat/chatActionCreator";
import { deleteUser, getAllUsers } from "../../store/reducers/user/userActionCreator";
import { useChatFormData } from "./chatForm";

export const useChatFunc = () => {
    const dispatch = useUserDispatch();
    const navigation = useNavigate();
    const { Users, IsLoading, Error } = useUserSelector(state => state.UserSlice);
    const { Chats, isLoading, error } = useUserSelector(state => state.ChatSlice);
    const [newMessages, setNewMessages] = useState<IChatNewMessages[]>([]);
    const { id } = useParams<{ id: any }>();
    const [user, setUser] = useState<IUserRead>();
    const { message, handle_Message_Change } = useChatFormData();
    const userStatusOnline: IUserChangeStatus = {
        id: id,
        isOnline: true
    }
    const userStatusOffline: IUserChangeStatus = {
        id: id,
        isOnline: false
    }

    const reloadClick = useCallback(async () => {
        await dispatch(getAllUsers());
    }, [dispatch]);

    const handleEdit = async (message: IChatChange | IChatNewMessages) => {
        const editedMessage = prompt("Enter the new message", message.message);
        if (editedMessage !== null) {
            await dispatch(changeMessage({ id: message.id, username: user?.username, message: editedMessage }));
            await dispatch(getAllMessages());
        }
    };

    const handleDelete = async (id: number | string, message: string) => {
        if (window.confirm('Are you sure you want to delete this message?')) {
            await dispatch(deleteMessage({ id: id, message: message }));
            await dispatch(getAllMessages());
            alert('Message deleted successfully!');
        }
    }

    const handleDeleteUser = async (User: IUserRead) => {
        await dispatch(deleteUser(User));
        await dispatch(getAllUsers());
    }

    const handleDeleteChat = async () => {
        await dispatch(clearChat());
        await dispatch(getAllMessages());
    }

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const dateTime = new Date();
        const date = `${dateTime.getFullYear()}-${dateTime.getMonth().toString().padStart(2, "0")}-${dateTime.getDate().toString().padStart(2, "0")}`
        const time = `${dateTime.getHours().toString().padStart(2, "0")}:${dateTime.getMinutes().toString().padStart(2, "0")}:${dateTime.getSeconds().toString().padStart(2, "0")}`
        const messageModel: IChatCreate = {
            username: user?.username,
            message: message,
            dispatchTime: `${date}T${time}`
        }
        await dispatch(createMessage(messageModel))
        setNewMessages([...newMessages, {
            id: `${Date.now()}`,
            username: messageModel.username,
            message: messageModel.message,
            dispatchTime: messageModel.dispatchTime,
        }]);
    }

    return {
        dispatch, navigation, Users, IsLoading, Error, Chats, isLoading, error, newMessages, 
        id, user, setUser, message, handle_Message_Change, userStatusOnline, userStatusOffline, reloadClick,
        handleEdit, handleDelete, handleDeleteUser, handleDeleteChat, handleSubmit
    }
}