import { Table, Button } from 'react-bootstrap/Table';

function DataTableWithNud({ data, inventory, handleQuantityChange, handleRemoveItem, onRowDoubleClick}) {
    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    {Object.keys(data[0]).map((key, index) => (
                        <th key={index}>{key}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {data.map((row, i) => {
                    const matchingInventory = inventory?.find(item => item.itemId === row.itemId);
                    const maxStock = matchingInventory ? matchingInventory.quantityInStock : 1;

                    // Need return because using curly braces!
                    return (
                        <tr key={i} onDoubleClick={() => onRowDoubleClick?.(row)}  >
                        {/*Access arr to see if column is the last row*/}
                            {Object.values(row).map((value, colIndex, arr) => (
                                <td key={colIndex}>
                                    {colIndex === arr.length - 1 ? (
                                        <input
                                            type="number"
                                            min="1"
                                            max={maxStock}
                                            defaultValue={value}
                                            onChange={(e) => handleQuantityChange(i, e.target.value)}
                                        />
                                    ) : (
                                        value
                                    )}
                                </td>
                            ))}
                            <td>
                                <Button
                                    variant="danger"
                                    size="sm"
                                    onClick={() => handleRemoveItem(i)}>
                                    Remove
                                </Button>
                            </td>
                        </tr>
                    );
                })}
            </tbody>
        </Table>
    )
}

export default DataTableWithNud;