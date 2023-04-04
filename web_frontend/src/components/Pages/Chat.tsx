import { useEffect } from "react";
import { IUserRead } from "../../models/user/IUserRead";
import { getAllMessages } from "../../store/reducers/chat/chatActionCreator";
import { changeUserStatus, getAllUsers, getUser } from "../../store/reducers/user/userActionCreator";
import { useChatFunc } from "../Assistance/chatFunc";

export default function Chat() {
    const { dispatch, navigation, Users, IsLoading, Error, Chats, isLoading, error, newMessages, 
        id, user, setUser, message, handle_Message_Change, userStatusOnline, userStatusOffline, reloadClick,
        handleEdit, handleDelete, handleDeleteUser, handleDeleteChat, handleSubmit } = useChatFunc();
    useEffect(() => {
        const fetchUserData = async () => {
            await dispatch(changeUserStatus(userStatusOnline));
            const response = await dispatch(getUser(id));
            setUser(response.payload as IUserRead);
            dispatch(getAllUsers());
        }
        const fetchChatData = async () => {
            await dispatch(getAllMessages());
        }
        fetchUserData();
        fetchChatData();
    }, [dispatch]);
    return (
        <div className="waveWrapper waveAnimation">
            <div className="chat-container">
                <header className="chat-header">
                    <h1>User: {user?.username}</h1>
                    <a href="#" className="btn" onClick={() => {
                        navigation('/');
                        dispatch(changeUserStatus(userStatusOffline));
                    }}>Log out</a>
                </header>
                <main className="chat-main">
                    <div className="chat-sidebar">
                        <h3><i className="fas fa-users"></i> Users
                            <button className="btn btn-update" onClick={reloadClick}>Reload</button>
                            {user?.isAdmin && (<button className="btn btn-update btn-users-update" onClick={handleDeleteChat}>Clear Chat</button>)}</h3>
                        {IsLoading && "Loading..."}
                        {Error && Error}
                        {Users.length > 0 && Users.map(User =>
                            <ul className="user-list">
                                <li key={User.id}>
                                    <p>{User.username} |
                                        <span className={User.isOnline ? "status-online" : "status-offline"}>
                                            <p></p>
                                        </span>
                                        {user?.isAdmin && (
                                            <button className="custom-btn delete-btn button-update" onClick={() => handleDeleteUser(User)}>Delete</button>
                                        )}
                                    </p>
                                </li>
                            </ul>)
                        }
                    </div>
                    <div className="chat-messages">
                        {error && error}
                        {isLoading && <p>Loading...</p>}
                        {Chats.length > 0 && Chats.map((chat) => (
                            <div className={`message message1 ${chat.username === user?.username ? 'from-me' : ''}`} key={chat.id}>
                                <p className="meta">
                                    {chat.username} <span>{chat.dispatchTime.substring(11)}</span>
                                </p>
                                <p className="text">{chat.message}</p>
                                {chat.username === user?.username && (
                                    <div className="buttons">
                                        <button className="custom-btn delete-btn" onClick={() => handleDelete(chat.id, chat.message)}>Delete</button>
                                        <button className="custom-btn change-btn" onClick={() => handleEdit(chat)}>Change</button>
                                    </div>
                                )}
                            </div>
                        ))}
                        {newMessages.length > 0 && (
                            <div>
                                {newMessages.map((message) => (
                                    <div className={`message ${message.username === user?.username ? 'from-me' : ''}`} key={message.id + '-' + message.username}>
                                        <p className="meta">
                                            {message.username} <span>{message.dispatchTime.substring(11)}</span>
                                        </p>
                                        <p className="text">{message.message}</p>
                                        {message.username === user?.username && (
                                            <div className="buttons">
                                                <button className="custom-btn delete-btn" onClick={() => handleDelete(message.id, message.message)}>Delete</button>
                                                <button className="custom-btn change-btn" onClick={() => handleEdit(message)}>Change</button>
                                            </div>
                                        )}
                                    </div>
                                ))}
                            </div>
                        )}
                    </div>
                </main>
                <footer className="chat-form-container">
                    <form onSubmit={handleSubmit} id="chat-form">
                        <div className="message-input">
                            <input value={message} onChange={handle_Message_Change} type="text" placeholder="Enter message..." required />
                            <button type="submit">Send</button>
                        </div>
                    </form>
                </footer>
            </div >
            <div className="waveWrapperInner bgTop">
                <div className="wave waveTop" style={{ backgroundImage: `url(http://front-end-noobs.com/jecko/img/wave-top.png)` }}></div>
            </div>
            <div className="waveWrapperInner bgMiddle">
                <div className="wave waveMiddle" style={{ backgroundImage: `url(http://front-end-noobs.com/jecko/img/wave-mid.png)` }}></div>
            </div>
            <div className="waveWrapperInner bgBottom">
                <div className="wave waveBottom" style={{ backgroundImage: `url(http://front-end-noobs.com/jecko/img/wave-bot.png)` }}></div>
            </div>
        </div >
    );
}