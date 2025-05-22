import axios from "axios";

const PRODUCT_API_URL = "https://localhost:7205/api/products";

const getAllProducts = async () => {
    try {
        const response =  await axios.get("https://localhost:7205/api/products/getAllProducts")

        console.log("Raw API Response:", response.data);

        // Handle case where response.data is the direct array
        if (Array.isArray(response.data)) {
            return response.data;
        }

        // Handle your standard { message, isSuccess, data } structure
        if (response.data && typeof response.data.isSuccess !== 'undefined') {
            if (!response.data.isSuccess) {
                throw new Error(response.data.message || "Request failed");
            }
            return response.data.data || []; // Return data or empty array
        }

        // Handle unexpected format
        console.warn("Unexpected response format:", response.data);
        throw new Error("Unexpected server response format");
    } catch (error) {
        console.error("API Request Failed:", {
            error: error.message,
            response: error.response?.data
        });
        throw error;
    }
};

export default { getAllProducts };