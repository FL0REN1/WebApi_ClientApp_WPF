import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { IUserChangeStatus } from "../../../models/user/IUserChangeStatus";
import { IUserCreate } from "../../../models/user/IUserCreate";
import { IUserDelete } from "../../../models/user/IUserDelete";
import { IUserLogin } from "../../../models/user/IUserLogin";
import { IUserRead } from "../../../models/user/IUserRead";

export const getAllUsers = createAsyncThunk(
    'user/getAllUsers',
    async (_, { rejectWithValue }) => {
        try {
            return await axios.get<IUserRead>('http://localhost:5026/api/User/').then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const getUser = createAsyncThunk(
    'user/getUser',
    async (id: number, { rejectWithValue }) => {
        try {
            return await axios.get<IUserRead>(`http://localhost:5026/api/User/id?id=${id}`).then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const createUser = createAsyncThunk(
    'user/createUser',
    async (user: IUserCreate, { rejectWithValue }) => {
        try {
            return await axios.post<IUserRead>('http://localhost:5026/api/User', user).then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const deleteUser = createAsyncThunk(
    'user/deleteUser',
    async (user: IUserDelete, { rejectWithValue }) => {
        try {
            return await axios.delete<IUserRead>('http://localhost:5026/api/User', { data: user }).then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const checkLoginUser = createAsyncThunk(
    'user/checkLogin',
    async (user: IUserLogin, { rejectWithValue }) => {
        try {
            return await axios.post<IUserRead>('http://localhost:5026/api/User/login', user).then(response => response.data)
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const changeUserStatus = createAsyncThunk(
    'user/changeStatus',
    async (user: IUserChangeStatus, { rejectWithValue }) => {
        try {
            return await axios.put(`http://localhost:5026/api/User/id?id=${user.id}&IsOnline=${user.isOnline}`).then(response => response.data)
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)
