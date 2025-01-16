![](https://www.mermaidchart.com/raw/3f9df8aa-2937-4182-80fb-eaf1637bf932?theme=dark&version=v0.1&format=svg)

A entidade **Jogador** representa o personagem, contendo atributos como nome, classe, nível e um inventário exclusivo. O **Jogador** pode visualizar e interagir com os itens disponíveis em seu inventário

A entidade **Inventário** é responsável pela gestão dos itens do jogador, permitindo operações como adicionar, remover, organizar itens e verificar a capacidade disponível. Para relacionar os itens ao inventário, temos a entidade intermediária **InventarioItem**, que é gerada automaticamente pelo ORM. Esta entidade armazena exclusivamente referências (IDs) de inventários, itens e quantidade de cada item

> [!NOTE]
> **Importante:** a classe **InventarioItem** não deve ser gerenciada manualmente pelo código, já que sua criação e manutenção são feitas pelo ORM

A classe **Item** é genérica, descrevendo itens com atributos como nome, descrição, peso, valor, e métodos como usar e parar de usar. Subtipos da classe incluem:
- **Arma:** com atributos adicionais como dano e durabilidade
- **Consumível:** com efeitos e duração limitada

As relações entre as entidades são definidas da seguinte forma:
- **Jogador e Inventário:** possuem uma relação *OneToOne* (um jogador possui exatamente um inventário)
- **Inventário e InventarioItem:** possuem uma relação *OneToMany* (um inventário pode conter várias instâncias de **InventarioItem**)
- **InventarioItem e Item:** possuem uma relação *ManyToOne* (um mesmo item pode estar presente em várias entradas de **InventarioItem**)

Por fim, considerando o sistema como um todo, a relação entre **Inventário e Item** pode ser vista como *ManyToMany*, mediada pela entidade **InventarioItem**

Segue a correção com ajustes gramaticais e de clareza:

Obs.: Novamente, reforço que a entidade intermediária `InventarioItem` não deve ser criada ou gerenciada manualmente, pois sua criação e manutenção são realizadas pelo ORM
