import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { IChatChange } from "../../../models/chat/IChatChange";
import { IChatCreate } from "../../../models/chat/IChatCreate";
import { IChatDelete } from "../../../models/chat/IChatDelete";
import { IChatRead } from "../../../models/chat/IChatRead";

export const getAllMessages = createAsyncThunk(
    'chat/getAllMessages',
    async (_, { rejectWithValue }) => {
        try {
            return await axios.get<IChatRead>('http://localhost:5163/api/Chat/').then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const getMessageById = createAsyncThunk(
    'chat/getMessage',
    async (id: number, { rejectWithValue }) => {
        try {
            return await axios.get<IChatRead>(`http://localhost:5163/api/Chat/id?id=${id}`).then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const createMessage = createAsyncThunk(
    'chat/createMessage',
    async (message: IChatCreate, { rejectWithValue }) => {
        try {
            return await axios.post<IChatRead>(`http://localhost:5163/api/Chat`, message).then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const deleteMessage = createAsyncThunk(
    'chat/deleteMessage',
    async (message: IChatDelete, { rejectWithValue }) => {
        try {
            return await axios.delete<IChatRead>(`http://localhost:5163/api/Chat/${message.id}`, {data: message}).then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const changeMessage = createAsyncThunk(
    'chat/changeMessage',
    async (message: IChatChange, { rejectWithValue }) => {
        try {
            return await axios.put<IChatRead>(`http://localhost:5163/api/Chat`, message).then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)

export const clearChat = createAsyncThunk(
    'chat/clearChat',
    async (_, { rejectWithValue }) => {
        try {
            return await axios.delete<IChatRead>(`http://localhost:5163/api/Chat`).then(response => response.data);
        } catch (error: any) {
            return rejectWithValue(error.message);
        }
    }
)