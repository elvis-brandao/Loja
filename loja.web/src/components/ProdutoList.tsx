import type { Produto }
  from "../types/Produto";

type ProdutoListProps = {
  produtos: Produto[];

  onExcluir: (
    id: number
  ) => Promise<void>;

  onEditar: (
    produto: Produto
  ) => void;
};

export function ProdutoList({
  produtos,
  onExcluir,
  onEditar
}: ProdutoListProps) {
  return (
    <ul>
      {produtos.map((produto) => (
        <li key={produto.id}>
          {produto.nome}
          {" - "}
          R$ {produto.preco}

          {" "}

          <button
            onClick={() =>
              onEditar(produto)}
          >
            Editar
          </button>

          {" "}

          <button
            onClick={() =>
              onExcluir(produto.id)}
          >
            Excluir
          </button>
        </li>
      ))}
    </ul>
  );
}