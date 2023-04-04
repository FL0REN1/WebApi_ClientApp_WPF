import { Route, Routes } from "react-router-dom";
import Chat from "./components/Pages/Chat";
import Login from "./components/Pages/Login";
import Register from "./components/Pages/Register";

export default function Navigation() {
    return (
        <Routes>
            <Route path="/" Component={Login} />
            <Route path="/register" Component={Register} />
            <Route path="/chat/:id" Component={Chat} />
        </Routes>
    );
}