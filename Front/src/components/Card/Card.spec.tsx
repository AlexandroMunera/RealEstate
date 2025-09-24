import { fireEvent, render, screen } from "@testing-library/react";
import { Card } from "./Card";
import type { Property } from "../../types/property";

const mockProperty: Property = {
  id: "1",
  name: "string",
  address: "string",
  price: 9,
  codeInternal: "string",
  year: 9,
  imageUrl: "string",
  owner: {
    id: "string",
    name: "string",
    address: "string",
    photo: "string",
    birthday: "string",
  },
};

describe("Card", () => {
  test("renders card", async () => {
    render(<Card data={mockProperty} onClick={() => {}} />);
    expect(screen.getByRole("heading")).toBeInTheDocument();
  });

  test("render property image", async () => {
    render(<Card data={mockProperty} onClick={() => { }} />);
    expect(screen.getByAltText(mockProperty.name)).toBeInTheDocument();
  })

  test("calls onClick when card is clicked", async () => {
    const mockOnClick = jest.fn();
    render(<Card data={mockProperty} onClick={mockOnClick} />);

    fireEvent.click(screen.getByRole('article'));

    expect(mockOnClick).toHaveBeenCalledWith(mockProperty.id);
    expect(mockOnClick).toHaveBeenCalledTimes(1);
  })
});
