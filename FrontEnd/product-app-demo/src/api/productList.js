import React, { useEffect, useState } from "react";
import productService from "./products/productsapi";

function ProductList() {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const loadProducts = async () => {
            try {
                const data = await productService.getAllProducts();
                
                // Final verification and normalization
                const productArray = Array.isArray(data) ? data : [data].filter(Boolean);
                
                setProducts(productArray);
                setError(null);
            } catch (err) {
                console.error("Failed to load products:", err);
                setError(err.message);
                setProducts([]);
            } finally {
                setLoading(false);
            }
        };

        loadProducts();
    }, []);

    if (loading) return <div className="loading">Loading products...</div>;
    if (error) return <div className="error">Error: {error}</div>;

    return (
        <div className="products">
            <h1>Product Catalog</h1>
            {products.length > 0 ? (
                <ul className="product-list">
                    {products.map((product, index) => (
                        <li key={product.id || `${product.name}-${index}`}>
                            <h3>{product.name}</h3>
                            <p>Price: ${product.price?.toFixed(2)}</p>
                            {product.description && (
                                <p>Description: {product.description}</p>
                            )}
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No products available</p>
            )}
        </div>
    );
}

export default ProductList;